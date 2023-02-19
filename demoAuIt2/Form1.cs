using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using AutoItX3Lib;
namespace demoAuIt2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        public Form1()
        {
            InitializeComponent();
        }
        AutoItX3 AU3 = new AutoItX3();
        private void button1_Click(object sender, EventArgs e)
        {
            //clike();
            bool loop = true;
            while (loop)
            {
                if ((GetAsyncKeyState((int)Keys.Q) & 0x8000) != 0)
                {
                    lblconsolse.Text = "ออก";
                    loop = false;
                    break; // หยุดการทำงานของลูป
                }
                clike();
            }
        }
        public void clike()
        {
            var pix = AU3.PixelSearch(0, 0, 1980, 1000, 0xFF7763, 1);
            try
            {
                if (pix.ToString() != "0")
                {
                    object[] pixCord = (object[])pix;
                    AU3.MouseMove((int)pixCord[0], (int)pixCord[1], 1);

                    AU3.MouseClick("LEFT", (int)pixCord[0], (int)pixCord[1], 1, 1);

                    lblconsolse.Text = pixCord[0].ToString() + "  -  " + pixCord[1].ToString();
                }
                else
                {
                    lblconsolse.Text = "ไม่เจอ";
                }
            }
            catch (Exception ex)
            {
                lblconsolse.Text = ex.Message;
            }
        }
    }
}
