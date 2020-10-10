using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace autoclicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool toggle = false;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt)
            {
                if (toggle == false)
                {
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }

                Thread.Sleep(50);
            }

            if (toggle == true)
            {
                DoMouseClick();
            }

                Make_click();
        }
        private void Make_click()
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                DoMouseClick();
            }
        }

        private void Stop_clicker()
        {
            timer.Enabled = false;
            button_start.Enabled = true;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold CTRL to click FAST!\r\n Press ALT to TOGGLE.");
            start_clicker();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            Stop_clicker();
        }

        private void start_clicker()
        {
            button_start.Enabled = false;
            timer.Interval = (int)interval_value.Value;
            timer.Enabled = true;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        public void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
    }
}
