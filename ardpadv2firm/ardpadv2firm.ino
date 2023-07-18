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
  SoftPWMSetFadeTime(ALL, 100, 500);

  Serial.begin(250000);
  Serial.setTimeout(10);
}

void loop() {

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

bool colUp = false;

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
      Serial.println("Sensor Data Recieved");

      break;

    case 'c':
      // colour update on
      colUp = true;
      for (int i=2; i<=13; i++) {
        colWriteHandler(i, 255);
      }
      break;

    case 'o':
      // colour update off
      if (colProfMem != "") {
        colProf(colProfMem);
      } 
      else {
        for (int i=2; i<=13; i++) {
          colWriteHandler(i, 0);
        }
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
