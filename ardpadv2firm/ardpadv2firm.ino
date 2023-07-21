#include <ArduinoJson.h>

#include <SoftPWM.h>
#include <SoftPWM_timer.h>

String serialData;
String trimData;
char msgType;
String colProfMem = "";

void(* resetFunc) (void) = 0;

void setup() {
  //pinMode(3, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);

  analogWrite(5, 0);
  analogWrite(6, 0);
  analogWrite(9, 0);
  analogWrite(10, 0);


  SoftPWMBegin();
  SoftPWMSet(2, 0);
  SoftPWMSet(3, 0);
  SoftPWMSet(4, 0);
  SoftPWMSet(7, 0);
  SoftPWMSet(8, 0);
  SoftPWMSet(11, 0);
  SoftPWMSet(12, 0);
  SoftPWMSet(13, 0);
  SoftPWMSetFadeTime(ALL, 50, 150);

  Serial.begin(250000);
  Serial.setTimeout(10);
}

bool sendSens = false;
char toSend[50];
int sensDigits[4];

void loop() {
  if (sendSens) {

    sensDigits[0] = analogRead(A0);
    sensDigits[1] = analogRead(A1);
    sensDigits[2] = analogRead(A2);
    sensDigits[3] = analogRead(A3);

    // Format the entire string manually with padding for 'U'
    sprintf(toSend, "yL%01d%03dD%01d%03dU%01d%03dR%01d%03dx",
        sensDigits[0] / 1000, sensDigits[0] % 1000,
        sensDigits[1] / 1000, sensDigits[1] % 1000,
        sensDigits[2] / 1000, sensDigits[2] % 1000,
        sensDigits[3] / 1000, sensDigits[3] % 1000);
    Serial.println(String(toSend));

  }
}

void colWriteHandler(int pin, int value) {
  if (pin == 5 || pin == 6 || pin == 9 || pin == 10) {
      analogWrite(pin, value);

      /*Serial.print("PWM Pin-");
      Serial.print(i);
      Serial.print(" : Set to-");
      Serial.println(val);*/

    } else {
      SoftPWMSet(pin, value);

      /*Serial.print("SoftPWM Pin-");
      Serial.print(i);
      Serial.print(" : Set to-");
      Serial.println(val);*/
    }
}

void colProf(String data) {
  // deseriealize json string
  // Serial.println("from colprof func " + data);

  StaticJsonDocument<192> doc;

  DeserializationError error = deserializeJson(doc, data);

  if (error) {
    Serial.print(F("deserializeJson() failed: "));
    Serial.println(error.f_str());
    return;
  }

  int val;

  for (int i=2; i<=13; i++) {
    val = doc[String(i)];
    colWriteHandler(i, val);

  }
}

void ledFadeSet(String trimIn) {
  int colPt = trimIn.indexOf(":");
  int fadeUpMs = trimIn.substring(0,colPt).toInt();
  int fadeDownMs = trimIn.substring(colPt+1).toInt();
  SoftPWMSetFadeTime(ALL, fadeUpMs, fadeDownMs);
}

void sensSendToggle() {
  if (sendSens == false) {
    sendSens = true;
    Serial.println("Sensor Send On!");
  } else {
    sendSens = false;
    Serial.println("Sensor Send Off!");
  }
}

bool colUp = false;

void writeFlash(int from, int to, int value) {
  for (int i=from; i<=to; i++) {
    colWriteHandler(i, value);
  }
}

void flashDirection(char dir, int writeVal) {
  switch (dir) {
    case 'L':
      writeFlash(11, 13, writeVal);
      break;
    case 'D':
      writeFlash(8, 10, writeVal);
      break;
    case 'U':
      writeFlash(5, 7, writeVal);
      break;
    case 'R':
      writeFlash(2, 4, writeVal);
      break;
  }
}

void serialEvent() {
  serialData = Serial.readStringUntil('x');

  msgType = serialData.charAt(0);
  trimData = serialData.substring(1);
  trimData.trim();

  // **dont declare new variables in switch, put it in a function**
  switch (msgType) {
    case 'a':
      // colour profile
      if (!colUp) {
        colProf(trimData);
        colProfMem = trimData;
      }

      break;

    case 'b':
      // sensor data
      sensSendToggle();

      break;

    case 'c':
      // colour update on
      colUp = true;
      flashDirection(trimData.charAt(0), 255);
      break;

    case 'o':
      // colour update off
      if (colProfMem != "") {
        colProf(colProfMem);
      } 
      else {
        flashDirection(trimData.charAt(0), 0);
      }
      colUp = false;
      break;

    case 'f':
      // led fade timing data
      ledFadeSet(trimData);
      break;

    case 'r':
      Serial.println("Restarting...");
      delay(500);
      resetFunc();
      break;

    default:
      Serial.println("Incorrect Command");
      break;

  }
}
