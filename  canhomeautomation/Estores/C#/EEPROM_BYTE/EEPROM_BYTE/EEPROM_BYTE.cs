using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EEPROM_BYTE
{
    
    public partial class EEPROM_BYTE : UserControl
    {
        
        public delegate void ReadClickedHandler();
        public delegate void WriteClickedHandler();

        public EEPROM_BYTE()
        {
            InitializeComponent();
        }
        public string Label
        {
            set { label3.Text = value; }
            get { return (label3.Text); }
        }
        public int Value
        {
            set
            {
                int aux = value;
                checkBox1.Checked = Convert.ToBoolean(aux & 1);
                aux = value;
                checkBox2.Checked = Convert.ToBoolean((aux & 2)>>1);
                aux = value;
                checkBox3.Checked = Convert.ToBoolean((aux & 4) >> 2);
                aux = value;
                checkBox4.Checked = Convert.ToBoolean((aux & 8) >> 3);
                aux = value;
                checkBox5.Checked = Convert.ToBoolean((aux & 16) >> 4);
                aux = value;
                checkBox6.Checked = Convert.ToBoolean((aux & 32) >> 5);
                aux = value;
                checkBox7.Checked = Convert.ToBoolean((aux & 64) >> 6);
                aux = value;
                checkBox8.Checked = Convert.ToBoolean((aux & 128) >> 7);
            }
            get { return (Convert.ToByte(checkBox1.Checked)*1+Convert.ToByte(checkBox2.Checked)*2+Convert.ToByte(checkBox3.Checked)*4+Convert.ToByte(checkBox4.Checked)*8+Convert.ToByte(checkBox5.Checked)*16+Convert.ToByte(checkBox6.Checked)*32+Convert.ToByte(checkBox7.Checked)*64+Convert.ToByte(checkBox8.Checked)*128); }
        }

        private void btread_Click(object sender, EventArgs e)
        {
            OnReadClicked();

        }
        private void btwrite_Click(object sender, EventArgs e)
        {
            OnWriteClicked();

        }

        [Category("Action")]
        [Description("Fires when the Read button is clicked.")]
        public event ReadClickedHandler ReadClicked;

        protected virtual void OnReadClicked()
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (ReadClicked != null)
            {
                ReadClicked();  // Notify Subscribers
            }
        }

        [Category("Action")]
        [Description("Fires when the Write button is clicked.")]
        public event WriteClickedHandler WriteClicked;

        protected virtual void OnWriteClicked()
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (WriteClicked != null)
            {
                WriteClicked();  // Notify Subscribers
            }
        }

        private void btwrite_Click_1(object sender, EventArgs e)
        {
            OnWriteClicked();
        }



    }
}