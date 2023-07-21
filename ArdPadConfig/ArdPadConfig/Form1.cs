using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO.Ports;
using SimWinInput;

/*
todo
- colour profile save
- - use json process but add if statement for if for save

- gamepad integration

- organize code
- - add comments
*/

namespace ArdPadConfig
{
    public partial class Form1 : Form
    {

        private SimGamePad sgp = SimGamePad.Instance;

        public Form1()
        {
            InitializeComponent();

            foreach (string portName in SerialPort.GetPortNames())
            {
                comPick.Items.Add(portName);
            }
            subBttn.Enabled = false;
            restartBttn.Enabled = false;
            chromBttn.Enabled = false;
            fadeSubBttn.Enabled = false;
            sensorComsBttn.Enabled = false;
        }

        private void comPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.PortName = comPick.Text;
        }

        private void comConnectBttn_Click(object sender, EventArgs e)
        {
            Button comBttn = (Button)sender;
            if (comBttn.Text == "Connect")
            {
                if (!port.IsOpen)
                {
                    try
                    {
                        port.Open();
                        subBttn.Enabled = true;
                        restartBttn.Enabled = true;
                        chromBttn.Enabled = true;
                        fadeSubBttn.Enabled = true;
                        sensorComsBttn.Enabled = true;
                        comBttn.Text = "Disconnect";
                        Console.WriteLine("Opened Port on " + port.PortName);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Couldn't open COM port");
                    }
                }
            }
            else
            {
                port.Close();
                Console.WriteLine("Closed Port on " + port.PortName);
                comPick.Enabled = true;
                comPick.Enabled = false;
                subBttn.Enabled = false;
                restartBttn.Enabled = false;
                chromBttn.Enabled = false;
                fadeSubBttn.Enabled = false;
                sensorComsBttn.Enabled = false;
                comBttn.Text = "Connect";
            }
            
        }

        private Dictionary<char, int> sensDict = new Dictionary<char, int>();
        private Dictionary<char, int> sensitiveDict = new Dictionary<char, int>();
        private int sensValInt = 0;

        private void initSensDict()
        {
            foreach (char direction in "LDUR")
            {
                sensDict.Add(direction, 0);
                sensitiveDict.Add(direction, 1024);
            }
            if (focusButton != null)
            {
                sensBox.Enabled = true;
                sensSlide.Enabled = true;
            }
            
        }

        static void PrintDictionaryContents(Dictionary<char, int> dictionary)
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            foreach (var kvp in dictionary)
            {
                output.Append($"{kvp.Key} : {kvp.Value} - ");
            }
            Console.WriteLine(output.ToString().TrimEnd('-', ' '));
        }

        private int keepBounds(int calc, Panel sensPanCol)
        {
            string dirFind = sensPanCol.Name.Substring(0, sensPanCol.Name.Length - 4) + "Disp";
            Control[] bttnCon = this.Controls.Find(dirFind, true);
            Control dispBttn = bttnCon[0];

            if (calc > 73)
            {

                double lightenPerc = 0.40;
                Color ogc = dispBttn.BackColor;
                int red = (int)Math.Min(255, ogc.R + (255 - ogc.R) * lightenPerc);
                int green = (int)Math.Min(255, ogc.G + (255 - ogc.G) * lightenPerc);
                int blue = (int)Math.Min(255, ogc.B + (255 - ogc.B) * lightenPerc);
                Color LightenColor = Color.FromArgb(red, green, blue);

                sensPanCol.BackColor = LightenColor;

                return 73;
            }
            else
            {

                double darkenPerc = 0.25;
                int red = (int)(dispBttn.BackColor.R * (1 - darkenPerc));
                int green = (int)(dispBttn.BackColor.G * (1 - darkenPerc));
                int blue = (int)(dispBttn.BackColor.B * (1 - darkenPerc));
                Color DarkenColor = Color.FromArgb(red, green, blue);

                sensPanCol.BackColor = DarkenColor;

                return calc;
            }
        }

        private Dictionary<char, bool> sentChk = new Dictionary<char, bool>();
        private char lastSent;

        private void initSentDict()
        {
            foreach (char dir in "LDUR")
            {
                sentChk.Add(dir, false);
            }
        }

        private void sgcHandler(char key, bool state)
        {
            if (state)
            {
                switch (key)
                {
                    case 'L':
                        // send X
                        sgp.SetControl(GamePadControl.X);
                        break;
                    case 'D':
                        // send A
                        sgp.SetControl(GamePadControl.A);
                        break;
                    case 'U':
                        // send Y
                        sgp.SetControl(GamePadControl.Y);
                        break;
                    case 'R':
                        // send B
                        sgp.SetControl(GamePadControl.B);
                        break;
                    default:
                        break;
                    
                }
                Console.WriteLine(sgp.State[0].Buttons.ToString());
            }
            else if (!state)
            {
                switch (key)
                {
                    case 'L':
                        // send X
                        sgp.ReleaseControl(GamePadControl.X);
                        break;
                    case 'D':
                        // send A
                        sgp.ReleaseControl(GamePadControl.A);
                        break;
                    case 'U':
                        // send Y
                        sgp.ReleaseControl(GamePadControl.Y);
                        break;
                    case 'R':
                        // send B
                        sgp.ReleaseControl(GamePadControl.B);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void controlHandler()
        {
            foreach (char key in "LDUR")
            {
                int sens = sensDict[key];
                int sensTiv = sensitiveDict[key];

                if (sens > sensTiv && !sentChk[key])
                {
                    sgcHandler(key, true);

                    port.Write("c" + key + "x");
                    //Console.WriteLine("ON : " + key + " ; " + sens + " : " + sensTiv);
                    lastSent = key;
                    sentChk[key] = true;
                }
                if (sens <= sensTiv && sentChk[key])
                {
                    sgcHandler(key, false);

                    port.Write("o" + lastSent + "x");
                    //Console.WriteLine("Sent: o" + lastSent + "x");
                    //Console.WriteLine("OFF : " + key + " ; " + sens + " : " + sensTiv);
                    sentChk[key] = false;
                }
            }
        }

        private void updateSensDisp(Panel sensDispPan, char key)
        {
            if (sensDict.Count > 0 && sensitiveDict.Count > 0)
            {
                sensDispPan.Width = keepBounds(73 * sensDict[key] / sensitiveDict[key], sensDispPan);
            }
        }

        private void updateSensDisp()
        {
            leftSens.Invoke(new Action(() => updateSensDisp(leftSens, 'L')));
            downSens.Invoke(new Action(() => updateSensDisp(downSens, 'D')));
            upSens.Invoke(new Action(() => updateSensDisp(upSens, 'U')));
            rightSens.Invoke(new Action(() => updateSensDisp(rightSens, 'R')));

            if (sensDict.Count > 0 && sensitiveDict.Count > 0)
            {
                controlHandler();
            }

            //PrintDictionaryContents(sensDict);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string incomeInfo = port.ReadExisting();
            //Console.WriteLine(incomeInfo);
            
            if (incomeInfo[0] == 'y' && incomeInfo.Length >= 22)
            {
                if (incomeInfo[21] == 'x')
                {
                    string income = incomeInfo;
                    int indexMult = 3;
                    foreach (char direction in "LDUR")
                    {
                        Int32.TryParse(income.Substring(income.IndexOf(direction) + 1, income.IndexOf(direction) + indexMult), out sensValInt);
                        sensDict[direction] = sensValInt;
                        indexMult = indexMult - 5;
                    }
                    updateSensDisp();

                    //PrintDictionaryContents(sensDict);
                }
            }
        }

        private void sendColorJson()
        {
            // submit colour profile
            Color lc = leftDisp.BackColor;
            Color dc = downDisp.BackColor;
            Color uc = upDisp.BackColor;
            Color rc = rightDisp.BackColor;

            int[] rgbValues = {
                lc.R, lc.G, lc.B, // left
                dc.R, dc.G, dc.B, // down
                uc.R, uc.G, uc.B, // up
                rc.R, rc.G, rc.B  // right
            };

            Dictionary<int, int> pinAssignments = new Dictionary<int, int>();

            for (int i = 0; i < rgbValues.Length; i++)
            {
                pinAssignments[13 - i] = rgbValues[i];
            }

            string json = JsonConvert.SerializeObject(pinAssignments, Formatting.None);

            string parsedColour = "a" + json + 'x';

            //Console.WriteLine("sent : " + parsedColour);
            port.Write(parsedColour);
        }

        private void subBttn_Click(object sender, EventArgs e)
        {
            sendColorJson();
        }

        private void slide_ValueChanged(object sender, EventArgs e)
        {
            TrackBar slideBar = (TrackBar)sender;
            if (slideBar.Name == "redSlide")
            {
                redBox.Text = slideBar.Value.ToString();
            }
            else if (slideBar.Name == "greenSlide")
            {
                greenBox.Text = slideBar.Value.ToString();
            }
            else if (slideBar.Name == "blueSlide")
            {
                blueBox.Text = slideBar.Value.ToString();
            }

            subBttn.BackColor = Color.FromArgb(redSlide.Value, greenSlide.Value, blueSlide.Value);
        }

        private bool rgbUpdate;

        private void rgbUpdateChk_CheckedChanged(object sender, EventArgs e)
        {
            rgbUpdate = rgbUpdateChk.Checked;
            unFocus();

        }

        private bool firstClick;

        private void colorChange()
        {
            if (rgbUpdate)
            {
                if (focusButton != null && firstClick == false)
                {
                    focusButton.BackColor = Color.FromArgb(redSlide.Value, greenSlide.Value, blueSlide.Value);
                    Color cc = focusButton.BackColor;
                    int r = 255 - cc.R;
                    int g = 255 - cc.G;
                    int b = 255 - cc.B;
                    focusButton.ForeColor = Color.FromArgb((int)(r), (int)(g), (int)(b));
                }
            }
        }

        private void sensChange()
        {
            if (focusButton != null)
            {
                sensitiveDict[Char.ToUpper(focusButton.Name[0])] = sensSlide.Value;
            }
            //PrintDictionaryContents(sensitiveDict);
        }

        private void redBox_TextChanged(object sender, EventArgs e)
        {
            int redInt;
            Int32.TryParse(redBox.Text, out redInt);
            if (redInt > 255)
            {
                redSlide.Value = 255;
                redBox.Text = "255";
            }
            else
            {
                redSlide.Value = redInt;
                colorChange();
            }   
        }

        private void greenBox_TextChanged(object sender, EventArgs e)
        {
            int greenInt;
            Int32.TryParse(greenBox.Text, out greenInt);
            if (greenInt > 255)
            {
                greenSlide.Value = 255;
                greenBox.Text = "255";
            }
            else
            {
                greenSlide.Value = greenInt;
                colorChange();
            }
        }

        private void blueBox_TextChanged(object sender, EventArgs e)
        {
            int blueInt;
            Int32.TryParse(blueBox.Text, out blueInt);
            if (blueInt > 255)
            {
                blueSlide.Value = 255;
                blueBox.Text = "255";
            }
            else
            {
                blueSlide.Value = blueInt;
                colorChange();
            }
        }

        private void Disp_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!rgbUpdate)
            {
                button.BackColor = Color.FromArgb(redSlide.Value, greenSlide.Value, blueSlide.Value);
            }
            if (sensorComsBttn.Text == "Stop" && focusButton != null && chromBttn.Text == "Chromate")
            {
                sensBox.Enabled = true;
                sensSlide.Enabled = true;
            }
        }

        private void restartBttn_Click(object sender, EventArgs e)
        {
            port.Write("rx");
            sensorComsBttn.Text = "Start";
            Console.WriteLine("Sent Restart");
        }

        private void fadeSubBttn_Click(object sender, EventArgs e)
        {
            int fadeUpMs = fadeUpSlide.Value;
            int fadeDownMs = fadeDownSlide.Value;

            String sendFadeStr = "f" + fadeUpMs.ToString() + ":" + fadeDownMs.ToString() + "x";
            port.Write(sendFadeStr);
            //Console.WriteLine("Sent : " + sendFadeStr);
        }

        private void fadeSlide_ValueChanged(object sender, EventArgs e)
        {
            // fade timing sliders change
            // init fadeslide obj
            TrackBar fadeSlideBar = (TrackBar)sender;
            // if fadeslide name is up, update box
            if (fadeSlideBar.Name == "fadeUpSlide")
            {
                fadeUpBox.Text = fadeSlideBar.Value.ToString();
            }
            // if fadeslide name is down, update box
            if (fadeSlideBar.Name == "fadeDownSlide")
            {
                fadeDownBox.Text = fadeSlideBar.Value.ToString();
            }
        }

        private void fadeUpBox_TextChanged(object sender, EventArgs e)
        {
            int fadeUpInt;
            Int32.TryParse(fadeUpBox.Text, out fadeUpInt);
            if (fadeUpInt > 1000)
            {
                fadeUpSlide.Value = 1000;
            } 
            else
            {
                fadeUpSlide.Value = fadeUpInt;
            }
        }

        private void fadeDownBox_TextChanged(object sender, EventArgs e)
        {
            int fadeDownInt;
            Int32.TryParse(fadeDownBox.Text, out fadeDownInt);
            if (fadeDownInt > 1000)
            {
                fadeDownSlide.Value = 1000;
            }
            else
            {
                fadeDownSlide.Value = fadeDownInt;
            }
        }

        private void sensSlide_ValueChanged(object sender, EventArgs e)
        {
            sensBox.Text = sensSlide.Value.ToString();
        }

        private void sensBox_TextChanged(object sender, EventArgs e)
        {
            int sensInt;
            Int32.TryParse(sensBox.Text, out sensInt);
            if (sensInt > 1024)
            {
                sensSlide.Value = 1024;
            }
            else
            {
                sensSlide.Value = sensInt;
                sensChange();

            }
        }

        private Color Rainbow(float progress)
        {
            float div = (Math.Abs(progress % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;

            switch ((int)div)
            {
                case 0:
                    return Color.FromArgb(255, ascending, 0);
                case 1:
                    return Color.FromArgb(descending, 255, 0);
                case 2:
                    return Color.FromArgb(0, 255, ascending);
                case 3:
                    return Color.FromArgb(0, descending, 255);
                case 4:
                    return Color.FromArgb(ascending, 0, 255);
                default: // case 5:
                    return Color.FromArgb(255, 0, descending);
            }
        }

        Boolean tBool = false;

        int chromaTimeScale = 1;
        float chromaProgScale = 0.00066f;

        private async void chromaThreadProc(Button colBttn)
        {
            // 0.00066 for 10 ms - slowest
            // 0.004 for 1 ms - fastest
            while (tBool)
            {
                for (float progress = 0.000f; progress <= 1.000f;)
                {
                    if (tBool)
                    {
                        Color c = Rainbow(progress);
                        // make thing here for sending values to specific directions
                        colBttn.BackColor = c;
                        progress += chromaProgScale;
                        await Task.Delay(chromaTimeScale);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            await Task.WhenAll();
        }

        int chromaDelay = 0;

        private async void chromBttn_Click(object sender, EventArgs e)
        {
            // make button toggleable
            if (chromBttn.Text == "Chromate")
            {
                chromBttn.Text = "Unchromate";
                tBool = true;
                chromaSendChkBx.Enabled = false;
                rgbUpdateChk.Checked = false;
                rgbUpdateChk.Enabled = false;
                if (chromaAllChkBx.Checked)
                {
                    int bef = chromaSpeedSlide.Value;
                    chromaSpeedSlide.Enabled = false;
                    chromDelaySlide.Enabled = false;
                    subBttn.Enabled = false;
                    chromaSpeedSlide.Value = 1;
                    chromaThreadProc(leftDisp);
                    await Task.Delay(chromaDelay);
                    chromaThreadProc(downDisp);
                    await Task.Delay(chromaDelay);
                    chromaThreadProc(upDisp);
                    await Task.Delay(chromaDelay);
                    chromaThreadProc(rightDisp);
                    chromaSpeedSlide.Value = bef;
                    chromaSpeedSlide.Enabled = true;
                    
                }
                CheckBox f = leftChkBx;
                if (f.Checked && f.Enabled)
                {
                    chromaThreadProc(leftDisp);
                }
                f = downChkBx;
                if (f.Checked && f.Enabled)
                {
                    chromaThreadProc(downDisp);
                }
                f = upChkBx;
                if (f.Checked && f.Enabled)
                {
                    chromaThreadProc(upDisp);
                }
                f = rightChkBx;
                if (f.Checked && f.Enabled)
                {
                    chromaThreadProc(rightDisp);
                }

                if (chromaSendChkBx.Checked)
                {
                    tSend = true;
                    chromaSend();
                }
                else
                {
                    tSend = false;
                }
            } 
            else
            {
                chromBttn.Text = "Chromate";
                chromaSendChkBx.Enabled = true;
                chromDelaySlide.Enabled = true;
                rgbUpdateChk.Enabled = true;
                subBttn.Enabled = true;
                tBool = false;
                tSend = false;
            }

            await Task.WhenAll();
        }

        private void chromaSpeedSlide_ValueChanged(object sender, EventArgs e)
        {
            chromaTimeScale = chromaSpeedSlide.Value;
            chromaProgScale = (chromaTimeScale-1) * (0.004f - 0.00066f) / (10-1) + 0.00066f;
        }

        bool tSend = false;

        private async void chromaSend()
        {
            while (tSend == true)
            {
                sendColorJson();
                await Task.Delay(5);
            }
            await Task.WhenAll();
        }

        private void chromaAllChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (chromaAllChkBx.Checked)
            {
                leftChkBx.Enabled = false;
                downChkBx.Enabled = false;
                upChkBx.Enabled = false;
                rightChkBx.Enabled = false;
            }
            else
            {
                leftChkBx.Enabled = true;
                downChkBx.Enabled = true;
                upChkBx.Enabled = true;
                rightChkBx.Enabled = true;
            }
        }

        private void chromDelaySlide_ValueChanged(object sender, EventArgs e)
        {
            chromaDelay = chromDelaySlide.Value;
        }

        private void refreshPortBttn_Click(object sender, EventArgs e)
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                comPick.Items.Clear();
                comPick.Items.Add(portName);
            }
        }

        private void sensorComsBttn_Click(object sender, EventArgs e)
        {
            Button sensComs = (Button)sender;
            if (sensComs.Text == "Start")
            {
                sgp.Initialize();
                sgp.PlugIn();
                sensDict.Clear();
                sensitiveDict.Clear();
                sentChk.Clear();
                initSensDict();
                initSentDict();
                port.Write("bx");
                sensComs.Text = "Stop";
            }
            else
            {
                sgp.Unplug();
                sgp.ShutDown();
                sensDict.Clear();
                port.Write("bx");
                sensComs.Text = "Start";
            }
        }

        private Button focusButton;

        private void focusUp(object sender, EventArgs e)
        {
            if (rgbUpdate)
            {
                unFocus();
                focusButton = (Button)sender;
                firstClick = true;
                redSlide.Value = focusButton.BackColor.R;
                greenSlide.Value = focusButton.BackColor.G;
                blueSlide.Value = focusButton.BackColor.B;

                if (sensorComsBttn.Text == "Stop")
                {
                    sensBox.Enabled = true;
                    sensSlide.Enabled = true;

                    sensSlide.Value = sensitiveDict[Char.ToUpper(focusButton.Name[0])];
                }

                firstClick = false;
            }
        }

        private void focusDown(object sender, EventArgs e)
        {
            focusButton = (Button)sender;
        }

        private void unFocus()
        {
            if (focusButton != null)
            {
                Color cc = focusButton.ForeColor;
                if (cc.R + cc.G + cc.B < 383)
                {
                    focusButton.ForeColor = Color.FromArgb(0, 0, 0);
                }
                else
                {
                    focusButton.ForeColor = Color.FromArgb(255, 255, 255);
                }

            }
            sensBox.Enabled = false;
            sensSlide.Enabled = false;
            focusButton = null;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            unFocus();
            this.ActiveControl = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sgp.ShutDown();
            
            if (port.IsOpen)
            {
                if (sensorComsBttn.Text == "Stop")
                {
                    port.Write("bx");
                }
                
                port.Close();
            }
        }
    }
}
