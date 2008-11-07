using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace Estores_Module_Configurator
{
    public partial class Form1 : Form
    {
        private enum types
        {
            SetValue = 1, GetValue, ValueAns, PingRec, PingAns, SetConf, GetConf, ConfAns,
            Reset, DirAdr, IndAdrConf, IndSetVal, man_val_change, newadr, Set_virtual_int, Get_virtual_int,
            Virtual_int_Ans, Set_glob_adr, Get_glob_adr, glob_adr_ans
        }
        EEPROM_BYTE.EEPROM_BYTE[] rele = new EEPROM_BYTE.EEPROM_BYTE[8];
        private struct strucMSG
        {
            public string Dadr;
            public string Dsubadr;
            public string Oadr;
            public string Osubadr;
            public int type;
            public string DataLenght;
            public string[] data;


        }
        public string ConvToHexStr(object obj)
        {
            if (obj.GetType().ToString() == "System.String")
            {
                string s;
                s = (string)obj;
                if (s.Length == 1)
                {
                    return "0" + s;
                }
                return s;

            }
            else
            {
                string s;
                s = Convert.ToString((int)obj, 16).ToUpper();
                if (s.Length == 1) return "0" + s;
                return s;
            }
        }
        public Form1()
        {
           // EEPROM_BYTE.EEPROM_BYTE [] rele = new EEPROM_BYTE.EEPROM_BYTE[8];
            InitializeComponent();
            serialPort1.NewLine = "\r";
            rele[0] = eeproM_BYTE00;
            rele[1] = eeproM_BYTE01;
            rele[2] = eeproM_BYTE02;
            rele[3] = eeproM_BYTE03;
            rele[4] = eeproM_BYTE04;
            rele[5] = eeproM_BYTE05;
            rele[6] = eeproM_BYTE06;
            rele[7] = eeproM_BYTE07;
            
            
            for (int x = 0; x < 8; ++x)
            {
                rele[x].Label = x.ToString();
               
            }
            string[] ports = SerialPort.GetPortNames();
            toolStripComboBox1.Items.AddRange(ports);
            if (Properties.Settings.Default.comport == "COM")
            {
                toolStripComboBox1.SelectedIndex = 0;
                Properties.Settings.Default.comport = toolStripComboBox1.Text;
                Properties.Settings.Default.Save();
            }
            else toolStripComboBox1.Text = Properties.Settings.Default.comport;
            serialPort1.PortName = toolStripComboBox1.Text;
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comport = toolStripComboBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            toolStripButton2.Enabled = false;
            toolStripButton1.Enabled = true;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = toolStripComboBox1.Text;
            serialPort1.Open();
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ReadClicked()
        {
            MessageBox.Show("ooooooooooooo");
            
        }

        private void eeproM_BYTE00_ReadClicked()
        {
            read_W_C_W(0);
         //   MessageBox.Show(eeproM_BYTE00.Value.ToString("X"));
        }

        private void eeproM_BYTE01_Load(object sender, EventArgs e)
        {

        }

        private void eeproM_BYTE01_ReadClicked()
        {
            read_W_C_W(1);
        }

        private void eeproM_BYTE02_ReadClicked()
        {
            read_W_C_W(2);
        }

        private void eeproM_BYTE03_ReadClicked()
        {
            read_W_C_W(3);
        }

        private void eeproM_BYTE04_ReadClicked()
        {
            read_W_C_W(4);
        }

        private void eeproM_BYTE05_ReadClicked()
        {
            read_W_C_W(5);
        }

        private void eeproM_BYTE06_ReadClicked()
        {
            read_W_C_W(6);
        }

        private void eeproM_BYTE07_ReadClicked()
        {
            read_W_C_W(7);
        }

        private void read_W_C_W(int subadr)
        {
            
            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr="00";
            msg.DataLenght="01";
            msg.type = (int)types.GetConf;
            msg.data[0] = ConvToHexStr(10 + subadr);
            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }
        private void write_W_C_W(int subadr)
        {

            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr = "00";
            msg.DataLenght = "02";
            msg.type = (int)types.SetConf;
            msg.data[0] = ConvToHexStr(10 + subadr);
            msg.data[1] = ConvToHexStr(rele[subadr].Value);
            
            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }
        private string strucTomessage(strucMSG msg)
        {
            string ret;
            ret = ":" + msg.Dadr + msg.Dsubadr + msg.Oadr + msg.Osubadr + ConvToHexStr(msg.type) + msg.DataLenght;
            for (int i = 0; i < Convert.ToInt16(msg.DataLenght); i++)
            {
                ret = ret + msg.data[i];
            }
            return ret;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) MessageBox.Show("Port Still Closed");
            else
            {
                strucMSG msg = new strucMSG();
                msg.data = new string[5];
                msg.Dadr = textBox1.Text;
                msg.Dsubadr = "00";
                msg.Oadr = "00";
                msg.Osubadr = "00";
                msg.DataLenght = "01";
                msg.type = (int)types.GetConf;
                for (int x = 0; x < 8; ++x)
                {
                    Thread.Sleep(100);
                    msg.data[0] = ConvToHexStr(10 + x);
                    serialPort1.WriteLine(strucTomessage(msg));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) MessageBox.Show("Port Still Closed");
            else
            {
                strucMSG msg = new strucMSG();
                msg.data = new string[5];
                msg.Dadr = textBox1.Text;
                msg.Dsubadr = "00";
                msg.Oadr = "00";
                msg.Osubadr = "00";
                msg.DataLenght = "02";
                msg.type = (int)types.SetConf;
                for (int x = 0; x < 8; ++x)
                {
                    Thread.Sleep(100);
                    msg.data[0] = ConvToHexStr(10 + x);
                    msg.data[1] = ConvToHexStr(rele[x].Value);
                    serialPort1.WriteLine(strucTomessage(msg));
                }
            }
        }

        private void eeproM_BYTE00_WriteClicked()
        {
            write_W_C_W(0);
        }

        private void eeproM_BYTE01_WriteClicked()
        {
            write_W_C_W(1);
        }

        private void eeproM_BYTE02_WriteClicked()
        {
            write_W_C_W(2);
        }

        private void eeproM_BYTE03_WriteClicked()
        {
            write_W_C_W(3);
        }

        private void eeproM_BYTE04_WriteClicked()
        {
            write_W_C_W(4);
        }

        private void eeproM_BYTE05_WriteClicked()
        {
            write_W_C_W(5);
        }

        private void eeproM_BYTE06_WriteClicked()
        {
            write_W_C_W(6);
        }

        private void eeproM_BYTE07_WriteClicked()
        {
            write_W_C_W(7);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str;
            strucMSG can_msg = new strucMSG();
            str = serialPort1.ReadLine();
            can_msg = MessageToStruct(str);
            
            if (can_msg.type == (int)types.ConfAns)
            {
                if (Int32.Parse(can_msg.data[0], System.Globalization.NumberStyles.HexNumber) > 9 & Int32.Parse(can_msg.data[0], System.Globalization.NumberStyles.HexNumber) < 18)
                {
                    rele[Int32.Parse(can_msg.data[0], System.Globalization.NumberStyles.HexNumber) - 10].Value = Int32.Parse(can_msg.data[1], System.Globalization.NumberStyles.HexNumber);
                   // MessageBox.Show(can_msg.data[1]);
                }
                else if (Int32.Parse(can_msg.data[0], System.Globalization.NumberStyles.HexNumber) ==20)
                {
                    eeproM_BYTE1.Value = Int32.Parse(can_msg.data[1], System.Globalization.NumberStyles.HexNumber);
                    // MessageBox.Show(can_msg.data[1]);
                } 
            }
            else if (can_msg.type == (int)types.PingAns)
            {
                MessageBox.Show("PONG");
                timer1.Enabled = true;
                
            }
        }
        private strucMSG MessageToStruct(string str)
        {
            strucMSG msg = new strucMSG();
            msg.data = new string[10];
            msg.Dadr = str.Substring(1, 2);
            msg.Dsubadr = str.Substring(3, 2);
            msg.Oadr = str.Substring(5, 2);
            msg.Osubadr = str.Substring(7, 2);
            msg.type = (System.Int32.Parse(str.Substring(9, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
            msg.DataLenght = str.Substring(11, 2);
            //MessageBox.Show(((System.Int32.Parse(msg.DataLenght, System.Globalization.NumberStyles.AllowHexSpecifier)) * 2).ToString());
            for (int i = 0; i < (System.Int32.Parse(msg.DataLenght, System.Globalization.NumberStyles.AllowHexSpecifier)); ++i)
            {
                msg.data[i] = str.Substring(13 + i*2, 2);
            }
            return msg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr = "00";
            msg.DataLenght = "02";
            msg.type = (int)types.SetConf;
            msg.data[0] = "04";
            msg.data[1] = ConvToHexStr(textBox2.Text);
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result=MessageBox.Show("Switch to new Adress?", "Question", buttons);
            if (result == DialogResult.Yes)
            {
                textBox1.Text = textBox2.Text;
            }
        

            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr = "00";
            msg.DataLenght = "00";
            msg.type = (int)types.Reset;
            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr = "00";
            msg.DataLenght = "00";
            msg.type = (int)types.PingRec;
            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!toolStripLabel2.Enabled)
            {
                toolStripLabel2.Enabled = true;
            }
            else if (toolStripLabel2.Enabled)
            {
                toolStripLabel2.Enabled = false;
                timer1.Enabled = false;
            }
        }

        private void eeproM_BYTE1_ReadClicked()
        {
            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr = "00";
            msg.DataLenght = "01";
            msg.type = (int)types.GetConf;
            msg.data[0] = ConvToHexStr(20);
            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }

        private void eeproM_BYTE1_WriteClicked()
        {
            strucMSG msg = new strucMSG();
            msg.data = new string[5];
            msg.Dadr = textBox1.Text;
            msg.Dsubadr = "00";
            msg.Oadr = "00";
            msg.Osubadr = "00";
            msg.DataLenght = "02";
            msg.type = (int)types.SetConf;
            msg.data[0] = ConvToHexStr(20);
            msg.data[1] = ConvToHexStr(eeproM_BYTE1.Value);

            if (serialPort1.IsOpen) serialPort1.WriteLine(strucTomessage(msg));
            else MessageBox.Show("Port Still Closed");
        }

        private void eeproM_BYTE00_Load(object sender, EventArgs e)
        {

        }
       
    }
}