namespace Estores_Module_Configurator
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.eeproM_BYTE00 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE01 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE02 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE03 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE04 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE05 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE06 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE07 = new EEPROM_BYTE.EEPROM_BYTE();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eeproM_BYTE1 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE4 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE5 = new EEPROM_BYTE.EEPROM_BYTE();
            this.eeproM_BYTE6 = new EEPROM_BYTE.EEPROM_BYTE();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(466, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "ComPort:";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Estores_Module_Configurator.Properties.Resources.media;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Open Com Port";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::Estores_Module_Configurator.Properties.Resources.exit;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Close Com Port";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Enabled = false;
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "PONG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Module Adr:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(30, 20);
            this.textBox1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(425, 393);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.eeproM_BYTE00);
            this.tabPage1.Controls.Add(this.eeproM_BYTE01);
            this.tabPage1.Controls.Add(this.eeproM_BYTE02);
            this.tabPage1.Controls.Add(this.eeproM_BYTE03);
            this.tabPage1.Controls.Add(this.eeproM_BYTE04);
            this.tabPage1.Controls.Add(this.eeproM_BYTE05);
            this.tabPage1.Controls.Add(this.eeproM_BYTE06);
            this.tabPage1.Controls.Add(this.eeproM_BYTE07);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(417, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "What Does What";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "For each Button Select The Relays Controled";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Write All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Read All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eeproM_BYTE00
            // 
            this.eeproM_BYTE00.Label = "0";
            this.eeproM_BYTE00.Location = new System.Drawing.Point(6, 265);
            this.eeproM_BYTE00.Name = "eeproM_BYTE00";
            this.eeproM_BYTE00.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE00.TabIndex = 7;
            this.eeproM_BYTE00.Value = 0;
            this.eeproM_BYTE00.Load += new System.EventHandler(this.eeproM_BYTE00_Load);
            this.eeproM_BYTE00.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE00_ReadClicked);
            this.eeproM_BYTE00.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE00_WriteClicked);
            // 
            // eeproM_BYTE01
            // 
            this.eeproM_BYTE01.Label = "0";
            this.eeproM_BYTE01.Location = new System.Drawing.Point(6, 228);
            this.eeproM_BYTE01.Name = "eeproM_BYTE01";
            this.eeproM_BYTE01.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE01.TabIndex = 6;
            this.eeproM_BYTE01.Value = 0;
            this.eeproM_BYTE01.Load += new System.EventHandler(this.eeproM_BYTE01_Load);
            this.eeproM_BYTE01.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE01_ReadClicked);
            this.eeproM_BYTE01.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE01_WriteClicked);
            // 
            // eeproM_BYTE02
            // 
            this.eeproM_BYTE02.Label = "0";
            this.eeproM_BYTE02.Location = new System.Drawing.Point(6, 191);
            this.eeproM_BYTE02.Name = "eeproM_BYTE02";
            this.eeproM_BYTE02.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE02.TabIndex = 5;
            this.eeproM_BYTE02.Value = 0;
            this.eeproM_BYTE02.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE02_ReadClicked);
            this.eeproM_BYTE02.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE02_WriteClicked);
            // 
            // eeproM_BYTE03
            // 
            this.eeproM_BYTE03.Label = "0";
            this.eeproM_BYTE03.Location = new System.Drawing.Point(6, 154);
            this.eeproM_BYTE03.Name = "eeproM_BYTE03";
            this.eeproM_BYTE03.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE03.TabIndex = 4;
            this.eeproM_BYTE03.Value = 0;
            this.eeproM_BYTE03.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE03_ReadClicked);
            this.eeproM_BYTE03.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE03_WriteClicked);
            // 
            // eeproM_BYTE04
            // 
            this.eeproM_BYTE04.Label = "0";
            this.eeproM_BYTE04.Location = new System.Drawing.Point(6, 117);
            this.eeproM_BYTE04.Name = "eeproM_BYTE04";
            this.eeproM_BYTE04.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE04.TabIndex = 3;
            this.eeproM_BYTE04.Value = 0;
            this.eeproM_BYTE04.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE04_ReadClicked);
            this.eeproM_BYTE04.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE04_WriteClicked);
            // 
            // eeproM_BYTE05
            // 
            this.eeproM_BYTE05.Label = "0";
            this.eeproM_BYTE05.Location = new System.Drawing.Point(6, 80);
            this.eeproM_BYTE05.Name = "eeproM_BYTE05";
            this.eeproM_BYTE05.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE05.TabIndex = 2;
            this.eeproM_BYTE05.Value = 0;
            this.eeproM_BYTE05.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE05_ReadClicked);
            this.eeproM_BYTE05.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE05_WriteClicked);
            // 
            // eeproM_BYTE06
            // 
            this.eeproM_BYTE06.Label = "0";
            this.eeproM_BYTE06.Location = new System.Drawing.Point(6, 43);
            this.eeproM_BYTE06.Name = "eeproM_BYTE06";
            this.eeproM_BYTE06.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE06.TabIndex = 1;
            this.eeproM_BYTE06.Value = 0;
            this.eeproM_BYTE06.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE06_ReadClicked);
            this.eeproM_BYTE06.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE06_WriteClicked);
            // 
            // eeproM_BYTE07
            // 
            this.eeproM_BYTE07.Label = "0";
            this.eeproM_BYTE07.Location = new System.Drawing.Point(6, 6);
            this.eeproM_BYTE07.Name = "eeproM_BYTE07";
            this.eeproM_BYTE07.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE07.TabIndex = 0;
            this.eeproM_BYTE07.Value = 0;
            this.eeproM_BYTE07.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE07_ReadClicked);
            this.eeproM_BYTE07.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE07_WriteClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.eeproM_BYTE1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(417, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Switch or Push Button";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Selected For Switch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Unselected For Push-Button";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "For each Button Select Operation Mode";
            // 
            // eeproM_BYTE1
            // 
            this.eeproM_BYTE1.Label = "0";
            this.eeproM_BYTE1.Location = new System.Drawing.Point(82, 145);
            this.eeproM_BYTE1.Name = "eeproM_BYTE1";
            this.eeproM_BYTE1.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE1.TabIndex = 1;
            this.eeproM_BYTE1.Value = 0;
            this.eeproM_BYTE1.ReadClicked += new EEPROM_BYTE.EEPROM_BYTE.ReadClickedHandler(this.eeproM_BYTE1_ReadClicked);
            this.eeproM_BYTE1.WriteClicked += new EEPROM_BYTE.EEPROM_BYTE.WriteClickedHandler(this.eeproM_BYTE1_WriteClicked);
            // 
            // eeproM_BYTE4
            // 
            this.eeproM_BYTE4.Label = "0";
            this.eeproM_BYTE4.Location = new System.Drawing.Point(6, 80);
            this.eeproM_BYTE4.Name = "eeproM_BYTE4";
            this.eeproM_BYTE4.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE4.TabIndex = 2;
            this.eeproM_BYTE4.Value = 0;
            // 
            // eeproM_BYTE5
            // 
            this.eeproM_BYTE5.Label = "0";
            this.eeproM_BYTE5.Location = new System.Drawing.Point(6, 43);
            this.eeproM_BYTE5.Name = "eeproM_BYTE5";
            this.eeproM_BYTE5.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE5.TabIndex = 1;
            this.eeproM_BYTE5.Value = 0;
            // 
            // eeproM_BYTE6
            // 
            this.eeproM_BYTE6.Label = "0";
            this.eeproM_BYTE6.Location = new System.Drawing.Point(6, 6);
            this.eeproM_BYTE6.Name = "eeproM_BYTE6";
            this.eeproM_BYTE6.Size = new System.Drawing.Size(237, 31);
            this.eeproM_BYTE6.TabIndex = 0;
            this.eeproM_BYTE6.Value = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(169, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(30, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Adr:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(205, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Program";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(286, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(367, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Ping";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 459);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE00;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE01;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE02;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE03;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE04;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE05;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE06;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE07;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE4;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE5;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private EEPROM_BYTE.EEPROM_BYTE eeproM_BYTE1;
        private System.Windows.Forms.Label label6;
    }
}

