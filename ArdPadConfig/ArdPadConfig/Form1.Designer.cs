namespace ArdPadConfig
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.redBox = new System.Windows.Forms.TextBox();
            this.greenBox = new System.Windows.Forms.TextBox();
            this.blueBox = new System.Windows.Forms.TextBox();
            this.leftDisp = new System.Windows.Forms.Button();
            this.downDisp = new System.Windows.Forms.Button();
            this.rightDisp = new System.Windows.Forms.Button();
            this.upDisp = new System.Windows.Forms.Button();
            this.redSlide = new System.Windows.Forms.TrackBar();
            this.greenSlide = new System.Windows.Forms.TrackBar();
            this.blueSlide = new System.Windows.Forms.TrackBar();
            this.subBttn = new System.Windows.Forms.Button();
            this.restartBttn = new System.Windows.Forms.Button();
            this.textInator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fadeUpSlide = new System.Windows.Forms.TrackBar();
            this.fadeUpBox = new System.Windows.Forms.TextBox();
            this.fadeDownSlide = new System.Windows.Forms.TrackBar();
            this.fadeDownBox = new System.Windows.Forms.TextBox();
            this.sensSlide = new System.Windows.Forms.TrackBar();
            this.sensBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fadeSubBttn = new System.Windows.Forms.Button();
            this.chromBttn = new System.Windows.Forms.Button();
            this.chromaSpeedSlide = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.chromaSendChkBx = new System.Windows.Forms.CheckBox();
            this.chromaAllChkBx = new System.Windows.Forms.CheckBox();
            this.upChkBx = new System.Windows.Forms.CheckBox();
            this.leftChkBx = new System.Windows.Forms.CheckBox();
            this.downChkBx = new System.Windows.Forms.CheckBox();
            this.rightChkBx = new System.Windows.Forms.CheckBox();
            this.chromDelaySlide = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeUpSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeDownSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromaSpeedSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromDelaySlide)).BeginInit();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.BaudRate = 250000;
            this.port.PortName = "COM6";
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // redBox
            // 
            this.redBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.redBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.redBox.Location = new System.Drawing.Point(25, 431);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(50, 20);
            this.redBox.TabIndex = 2;
            this.redBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.redBox.TextChanged += new System.EventHandler(this.redBox_TextChanged);
            // 
            // greenBox
            // 
            this.greenBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.greenBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.greenBox.Location = new System.Drawing.Point(96, 431);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(50, 20);
            this.greenBox.TabIndex = 3;
            this.greenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.greenBox.TextChanged += new System.EventHandler(this.greenBox_TextChanged);
            // 
            // blueBox
            // 
            this.blueBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.blueBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.blueBox.Location = new System.Drawing.Point(168, 431);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(50, 20);
            this.blueBox.TabIndex = 4;
            this.blueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.blueBox.TextChanged += new System.EventHandler(this.blueBox_TextChanged);
            // 
            // leftDisp
            // 
            this.leftDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.leftDisp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftDisp.Location = new System.Drawing.Point(180, 106);
            this.leftDisp.Name = "leftDisp";
            this.leftDisp.Size = new System.Drawing.Size(75, 75);
            this.leftDisp.TabIndex = 6;
            this.leftDisp.Text = "Left";
            this.leftDisp.UseVisualStyleBackColor = false;
            this.leftDisp.Click += new System.EventHandler(this.Disp_Click);
            // 
            // downDisp
            // 
            this.downDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.downDisp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downDisp.Location = new System.Drawing.Point(254, 180);
            this.downDisp.Name = "downDisp";
            this.downDisp.Size = new System.Drawing.Size(75, 75);
            this.downDisp.TabIndex = 7;
            this.downDisp.Text = "Down";
            this.downDisp.UseVisualStyleBackColor = false;
            this.downDisp.Click += new System.EventHandler(this.Disp_Click);
            // 
            // rightDisp
            // 
            this.rightDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rightDisp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightDisp.Location = new System.Drawing.Point(328, 106);
            this.rightDisp.Name = "rightDisp";
            this.rightDisp.Size = new System.Drawing.Size(75, 75);
            this.rightDisp.TabIndex = 9;
            this.rightDisp.Text = "Right";
            this.rightDisp.UseVisualStyleBackColor = false;
            this.rightDisp.Click += new System.EventHandler(this.Disp_Click);
            // 
            // upDisp
            // 
            this.upDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.upDisp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upDisp.Location = new System.Drawing.Point(254, 32);
            this.upDisp.Name = "upDisp";
            this.upDisp.Size = new System.Drawing.Size(75, 75);
            this.upDisp.TabIndex = 8;
            this.upDisp.Text = "Up";
            this.upDisp.UseVisualStyleBackColor = false;
            this.upDisp.Click += new System.EventHandler(this.Disp_Click);
            // 
            // redSlide
            // 
            this.redSlide.Location = new System.Drawing.Point(28, 289);
            this.redSlide.Maximum = 255;
            this.redSlide.Name = "redSlide";
            this.redSlide.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.redSlide.Size = new System.Drawing.Size(45, 136);
            this.redSlide.TabIndex = 10;
            this.redSlide.TickFrequency = 20;
            this.redSlide.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.redSlide.ValueChanged += new System.EventHandler(this.slide_ValueChanged);
            // 
            // greenSlide
            // 
            this.greenSlide.Location = new System.Drawing.Point(99, 289);
            this.greenSlide.Maximum = 255;
            this.greenSlide.Name = "greenSlide";
            this.greenSlide.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.greenSlide.Size = new System.Drawing.Size(45, 136);
            this.greenSlide.TabIndex = 11;
            this.greenSlide.TickFrequency = 20;
            this.greenSlide.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.greenSlide.ValueChanged += new System.EventHandler(this.slide_ValueChanged);
            // 
            // blueSlide
            // 
            this.blueSlide.Location = new System.Drawing.Point(171, 289);
            this.blueSlide.Maximum = 255;
            this.blueSlide.Name = "blueSlide";
            this.blueSlide.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.blueSlide.Size = new System.Drawing.Size(45, 136);
            this.blueSlide.TabIndex = 12;
            this.blueSlide.TickFrequency = 20;
            this.blueSlide.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.blueSlide.ValueChanged += new System.EventHandler(this.slide_ValueChanged);
            // 
            // subBttn
            // 
            this.subBttn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.subBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subBttn.Location = new System.Drawing.Point(264, 116);
            this.subBttn.Name = "subBttn";
            this.subBttn.Size = new System.Drawing.Size(55, 55);
            this.subBttn.TabIndex = 13;
            this.subBttn.Text = "Submit Colour Profile";
            this.subBttn.UseVisualStyleBackColor = false;
            this.subBttn.Click += new System.EventHandler(this.subBttn_Click);
            // 
            // restartBttn
            // 
            this.restartBttn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.restartBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartBttn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.restartBttn.Location = new System.Drawing.Point(271, 480);
            this.restartBttn.Name = "restartBttn";
            this.restartBttn.Size = new System.Drawing.Size(100, 23);
            this.restartBttn.TabIndex = 14;
            this.restartBttn.Text = "Restart Arduino";
            this.restartBttn.UseVisualStyleBackColor = false;
            this.restartBttn.Click += new System.EventHandler(this.restartBttn_Click);
            // 
            // textInator
            // 
            this.textInator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textInator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textInator.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textInator.Location = new System.Drawing.Point(405, 490);
            this.textInator.Multiline = true;
            this.textInator.Name = "textInator";
            this.textInator.Size = new System.Drawing.Size(130, 49);
            this.textInator.TabIndex = 15;
            this.textInator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textInator_KeyDown);
            this.textInator.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textInator_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(42, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(113, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(186, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(362, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fade Up Time (ms)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(464, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fade Down Time (ms)";
            // 
            // fadeUpSlide
            // 
            this.fadeUpSlide.LargeChange = 10;
            this.fadeUpSlide.Location = new System.Drawing.Point(388, 289);
            this.fadeUpSlide.Maximum = 1000;
            this.fadeUpSlide.Name = "fadeUpSlide";
            this.fadeUpSlide.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.fadeUpSlide.Size = new System.Drawing.Size(45, 136);
            this.fadeUpSlide.SmallChange = 5;
            this.fadeUpSlide.TabIndex = 22;
            this.fadeUpSlide.TickFrequency = 100;
            this.fadeUpSlide.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.fadeUpSlide.ValueChanged += new System.EventHandler(this.fadeSlide_ValueChanged);
            // 
            // fadeUpBox
            // 
            this.fadeUpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.fadeUpBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fadeUpBox.Location = new System.Drawing.Point(385, 431);
            this.fadeUpBox.Name = "fadeUpBox";
            this.fadeUpBox.Size = new System.Drawing.Size(50, 20);
            this.fadeUpBox.TabIndex = 21;
            this.fadeUpBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fadeUpBox.TextChanged += new System.EventHandler(this.fadeUpBox_TextChanged);
            // 
            // fadeDownSlide
            // 
            this.fadeDownSlide.LargeChange = 10;
            this.fadeDownSlide.Location = new System.Drawing.Point(491, 289);
            this.fadeDownSlide.Maximum = 1000;
            this.fadeDownSlide.Name = "fadeDownSlide";
            this.fadeDownSlide.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.fadeDownSlide.Size = new System.Drawing.Size(45, 136);
            this.fadeDownSlide.SmallChange = 5;
            this.fadeDownSlide.TabIndex = 24;
            this.fadeDownSlide.TickFrequency = 100;
            this.fadeDownSlide.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.fadeDownSlide.ValueChanged += new System.EventHandler(this.fadeSlide_ValueChanged);
            // 
            // fadeDownBox
            // 
            this.fadeDownBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.fadeDownBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fadeDownBox.Location = new System.Drawing.Point(488, 431);
            this.fadeDownBox.Name = "fadeDownBox";
            this.fadeDownBox.Size = new System.Drawing.Size(50, 20);
            this.fadeDownBox.TabIndex = 23;
            this.fadeDownBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fadeDownBox.TextChanged += new System.EventHandler(this.fadeDownBox_TextChanged);
            // 
            // sensSlide
            // 
            this.sensSlide.Location = new System.Drawing.Point(269, 289);
            this.sensSlide.Maximum = 1024;
            this.sensSlide.Name = "sensSlide";
            this.sensSlide.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sensSlide.Size = new System.Drawing.Size(45, 136);
            this.sensSlide.TabIndex = 27;
            this.sensSlide.TickFrequency = 64;
            this.sensSlide.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sensSlide.ValueChanged += new System.EventHandler(this.sensSlide_ValueChanged);
            // 
            // sensBox
            // 
            this.sensBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.sensBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sensBox.Location = new System.Drawing.Point(266, 431);
            this.sensBox.Name = "sensBox";
            this.sensBox.Size = new System.Drawing.Size(50, 20);
            this.sensBox.TabIndex = 26;
            this.sensBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sensBox.TextChanged += new System.EventHandler(this.sensBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(264, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Sensitivity";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "TestPad";
            // 
            // fadeSubBttn
            // 
            this.fadeSubBttn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.fadeSubBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fadeSubBttn.Location = new System.Drawing.Point(375, 206);
            this.fadeSubBttn.Name = "fadeSubBttn";
            this.fadeSubBttn.Size = new System.Drawing.Size(187, 49);
            this.fadeSubBttn.TabIndex = 29;
            this.fadeSubBttn.Text = "Submit Fade Times (Global)";
            this.fadeSubBttn.UseVisualStyleBackColor = false;
            this.fadeSubBttn.Click += new System.EventHandler(this.fadeSubBttn_Click);
            // 
            // chromBttn
            // 
            this.chromBttn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.chromBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chromBttn.Location = new System.Drawing.Point(282, 520);
            this.chromBttn.Name = "chromBttn";
            this.chromBttn.Size = new System.Drawing.Size(75, 23);
            this.chromBttn.TabIndex = 30;
            this.chromBttn.Text = "Chromate";
            this.chromBttn.UseVisualStyleBackColor = false;
            this.chromBttn.Click += new System.EventHandler(this.chromBttn_Click);
            // 
            // chromaSpeedSlide
            // 
            this.chromaSpeedSlide.Location = new System.Drawing.Point(151, 528);
            this.chromaSpeedSlide.Minimum = 1;
            this.chromaSpeedSlide.Name = "chromaSpeedSlide";
            this.chromaSpeedSlide.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chromaSpeedSlide.Size = new System.Drawing.Size(104, 45);
            this.chromaSpeedSlide.TabIndex = 31;
            this.chromaSpeedSlide.Value = 1;
            this.chromaSpeedSlide.ValueChanged += new System.EventHandler(this.chromaSpeedSlide_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(185, 515);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Speed";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chromaSendChkBx
            // 
            this.chromaSendChkBx.AutoSize = true;
            this.chromaSendChkBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chromaSendChkBx.Location = new System.Drawing.Point(88, 532);
            this.chromaSendChkBx.Name = "chromaSendChkBx";
            this.chromaSendChkBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chromaSendChkBx.Size = new System.Drawing.Size(48, 17);
            this.chromaSendChkBx.TabIndex = 33;
            this.chromaSendChkBx.Text = "Send";
            this.chromaSendChkBx.UseVisualStyleBackColor = true;
            // 
            // chromaAllChkBx
            // 
            this.chromaAllChkBx.AutoSize = true;
            this.chromaAllChkBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chromaAllChkBx.Location = new System.Drawing.Point(57, 506);
            this.chromaAllChkBx.Name = "chromaAllChkBx";
            this.chromaAllChkBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chromaAllChkBx.Size = new System.Drawing.Size(12, 11);
            this.chromaAllChkBx.TabIndex = 34;
            this.chromaAllChkBx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chromaAllChkBx.UseVisualStyleBackColor = true;
            this.chromaAllChkBx.CheckedChanged += new System.EventHandler(this.chromaAllChkBx_CheckedChanged);
            // 
            // upChkBx
            // 
            this.upChkBx.AutoSize = true;
            this.upChkBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upChkBx.Location = new System.Drawing.Point(58, 482);
            this.upChkBx.Name = "upChkBx";
            this.upChkBx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.upChkBx.Size = new System.Drawing.Size(37, 17);
            this.upChkBx.TabIndex = 35;
            this.upChkBx.Text = "Up";
            this.upChkBx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.upChkBx.UseVisualStyleBackColor = true;
            // 
            // leftChkBx
            // 
            this.leftChkBx.AutoSize = true;
            this.leftChkBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftChkBx.Location = new System.Drawing.Point(7, 503);
            this.leftChkBx.Name = "leftChkBx";
            this.leftChkBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.leftChkBx.Size = new System.Drawing.Size(41, 17);
            this.leftChkBx.TabIndex = 36;
            this.leftChkBx.Text = "Left";
            this.leftChkBx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.leftChkBx.UseVisualStyleBackColor = true;
            // 
            // downChkBx
            // 
            this.downChkBx.AutoSize = true;
            this.downChkBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downChkBx.Location = new System.Drawing.Point(18, 524);
            this.downChkBx.Name = "downChkBx";
            this.downChkBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.downChkBx.Size = new System.Drawing.Size(51, 17);
            this.downChkBx.TabIndex = 37;
            this.downChkBx.Text = "Down";
            this.downChkBx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.downChkBx.UseVisualStyleBackColor = true;
            // 
            // rightChkBx
            // 
            this.rightChkBx.AutoSize = true;
            this.rightChkBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightChkBx.Location = new System.Drawing.Point(78, 503);
            this.rightChkBx.Name = "rightChkBx";
            this.rightChkBx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rightChkBx.Size = new System.Drawing.Size(48, 17);
            this.rightChkBx.TabIndex = 38;
            this.rightChkBx.Text = "Right";
            this.rightChkBx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rightChkBx.UseVisualStyleBackColor = true;
            // 
            // chromDelaySlide
            // 
            this.chromDelaySlide.Location = new System.Drawing.Point(151, 482);
            this.chromDelaySlide.Maximum = 500;
            this.chromDelaySlide.Name = "chromDelaySlide";
            this.chromDelaySlide.Size = new System.Drawing.Size(104, 45);
            this.chromDelaySlide.TabIndex = 39;
            this.chromDelaySlide.TickFrequency = 50;
            this.chromDelaySlide.ValueChanged += new System.EventHandler(this.chromDelaySlide_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(172, 469);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Effect Speed";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rightChkBx);
            this.Controls.Add(this.downChkBx);
            this.Controls.Add(this.leftChkBx);
            this.Controls.Add(this.upChkBx);
            this.Controls.Add(this.chromaAllChkBx);
            this.Controls.Add(this.chromaSendChkBx);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chromaSpeedSlide);
            this.Controls.Add(this.chromBttn);
            this.Controls.Add(this.fadeSubBttn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sensSlide);
            this.Controls.Add(this.sensBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fadeDownSlide);
            this.Controls.Add(this.fadeDownBox);
            this.Controls.Add(this.fadeUpSlide);
            this.Controls.Add(this.fadeUpBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textInator);
            this.Controls.Add(this.restartBttn);
            this.Controls.Add(this.subBttn);
            this.Controls.Add(this.blueSlide);
            this.Controls.Add(this.greenSlide);
            this.Controls.Add(this.redSlide);
            this.Controls.Add(this.rightDisp);
            this.Controls.Add(this.upDisp);
            this.Controls.Add(this.downDisp);
            this.Controls.Add(this.leftDisp);
            this.Controls.Add(this.blueBox);
            this.Controls.Add(this.greenBox);
            this.Controls.Add(this.redBox);
            this.Controls.Add(this.chromDelaySlide);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pad Config";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeUpSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeDownSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromaSpeedSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromDelaySlide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.TextBox redBox;
        private System.Windows.Forms.TextBox greenBox;
        private System.Windows.Forms.TextBox blueBox;
        private System.Windows.Forms.Button leftDisp;
        private System.Windows.Forms.Button downDisp;
        private System.Windows.Forms.Button rightDisp;
        private System.Windows.Forms.Button upDisp;
        private System.Windows.Forms.TrackBar redSlide;
        private System.Windows.Forms.TrackBar greenSlide;
        private System.Windows.Forms.TrackBar blueSlide;
        private System.Windows.Forms.Button subBttn;
        private System.Windows.Forms.Button restartBttn;
        private System.Windows.Forms.TextBox textInator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar fadeUpSlide;
        private System.Windows.Forms.TextBox fadeUpBox;
        private System.Windows.Forms.TrackBar fadeDownSlide;
        private System.Windows.Forms.TextBox fadeDownBox;
        private System.Windows.Forms.TrackBar sensSlide;
        private System.Windows.Forms.TextBox sensBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button fadeSubBttn;
        private System.Windows.Forms.Button chromBttn;
        private System.Windows.Forms.TrackBar chromaSpeedSlide;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chromaSendChkBx;
        private System.Windows.Forms.CheckBox chromaAllChkBx;
        private System.Windows.Forms.CheckBox upChkBx;
        private System.Windows.Forms.CheckBox leftChkBx;
        private System.Windows.Forms.CheckBox downChkBx;
        private System.Windows.Forms.CheckBox rightChkBx;
        private System.Windows.Forms.TrackBar chromDelaySlide;
        private System.Windows.Forms.Label label9;
    }
}

