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

namespace ArdPadConfig
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            port.Open();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(port.ReadExisting());
            
        }

        private void subBttn_Click(object sender, EventArgs e)
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
                pinAssignments[13-i] = rgbValues[i];
            }

            string json = JsonConvert.SerializeObject(pinAssignments, Formatting.None);

            string parsedColour = "a" + json + 'x';

            Console.WriteLine("sent : " + parsedColour);
            port.Write(parsedColour);
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
            }
        }

        private void Disp_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(redSlide.Value, greenSlide.Value, blueSlide.Value);

        }

        private void restartBttn_Click(object sender, EventArgs e)
        {
            port.Write("rx");
            Console.WriteLine("Sent Restart");
        }

        private void textInator_KeyDown(object sender, KeyEventArgs e)
        {
            port.Write("cx");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "C:/Users/Lenovo/Music/RIZZ Sound Effect1.wav";
            player.Play();
        }

        private void textInator_KeyUp(object sender, KeyEventArgs e)
        {
            port.Write("ox");
        }

        private void fadeSubBttn_Click(object sender, EventArgs e)
        {
            int fadeUpMs = fadeUpSlide.Value;
            int fadeDownMs = fadeDownSlide.Value;

            String sendFadeStr = "f" + fadeUpMs.ToString() + ":" + fadeDownMs.ToString() + "x";
            port.Write(sendFadeStr);
            Console.WriteLine("Sent : " + sendFadeStr);
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

        private async void chromaThreadProc()
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
                        redSlide.Value = c.R;
                        greenSlide.Value = c.G;
                        blueSlide.Value = c.B;
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

        private void chromBttn_Click(object sender, EventArgs e)
        {
            // make button toggleable
            if (chromBttn.Text == "Chromate")
            {
                chromBttn.Text = "Unchromate";
                tBool = true;
                chromaThreadProc();
            } 
            else
            {
                chromBttn.Text = "Chromate";
                tBool = false;
            }


        }

        private void chromaSpeedSlide_ValueChanged(object sender, EventArgs e)
        {
            chromaTimeScale = chromaSpeedSlide.Value;
            chromaProgScale = (chromaTimeScale-1) * (0.004f - 0.00066f) / (10-1) + 0.00066f;
        }

        private void sendChkBx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chromaAllChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (chromaAllChkBx.Checked)
            {
                chromaIndivChkBx.Enabled = false;
            }
            else
            {
                chromaIndivChkBx.Enabled = true;

            }
        }

        private void chromaIndivChkBx_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
