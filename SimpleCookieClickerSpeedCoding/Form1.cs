using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCookieClickerSpeedCoding
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        double Cookies = 0.0;
        double PerSecondCookies = 0.0;
        double PerSecondsCookieAddOnePrice = 10.0;
        Boolean startedThread = false;
        Boolean x2 = false;

        async void startCookieClicker()
        {
            while (true)
            {
                await Task.Delay(1000);
                if(PerSecondCookies > 0.0)
                {
                    Cookies = Cookies + PerSecondCookies;
                    MethodInvoker inv = delegate
                    {
                        this.metroLabel2.Text = "Cookies: " + this.Cookies.ToString();
                    };

                    try
                    {
                        this.Invoke(inv);
                    } catch
                    {
                        MessageBox.Show("An internal error occurred while adding cookies per second.", "Cookie Adding Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        async void startX2()
        {
            while (true)
            {
                if(x2) {
                    await Task.Delay(30000);
                    x2 = false;
                    MethodInvoker inv = delegate
                    {
                        this.metroButton1.Enabled = true;
                    };

                    try
                    {
                        this.Invoke(inv);
                    }
                    catch
                    {
                        MessageBox.Show("An internal error occurred while enableing x2 Button.", "Cookie Button Enable Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private bool checkCoins(double needed)
        {
            if(Cookies == needed || Cookies > needed) {
                return true;
            } else {
                return false;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (!startedThread)
            {
                startedThread = true;
                Thread threadPerSecondCookies = new Thread(startCookieClicker);
                threadPerSecondCookies.Start();

                Thread threadX2 = new Thread(startX2);
                threadX2.Start();

            }

            if (Cookies == 0)
            {
                Cookies = 1;
            }
            else
            {
                if(x2) {
                    Cookies = Cookies + 2;
                } else {
                    Cookies = Cookies + 1;
                }
            }
            metroLabel2.Text = "Cookies: " + Cookies.ToString();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (checkCoins(PerSecondsCookieAddOnePrice)) {
                Cookies = Cookies - PerSecondsCookieAddOnePrice;
                PerSecondsCookieAddOnePrice = PerSecondsCookieAddOnePrice * 2;
                PerSecondCookies = PerSecondCookies + 0.1;
                metroLabel3.Text = PerSecondsCookieAddOnePrice + " Cookies | Current: " + PerSecondCookies;
                metroLabel2.Text = "Cookies: " + Cookies.ToString();
            } else {
                MessageBox.Show("You cannot purchase this product because you do not have enough cookies.", "Not enough cookies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            x2 = true;
            if (checkCoins(35)) {
                metroButton1.Enabled = false;
                Cookies = Cookies - 35;
                metroLabel2.Text = "Cookies: " + Cookies.ToString();
            } else {
                MessageBox.Show("You cannot purchase this product because you do not have enough cookies.", "Not enough cookies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            Cookies = 0.0;
            PerSecondCookies = 0.0;
            PerSecondsCookieAddOnePrice = 10.0;
            startedThread = false;
            x2 = false;

            metroLabel2.Text = "Cookies: " + Cookies.ToString();
            metroLabel3.Text = PerSecondsCookieAddOnePrice + " Cookies | Current: " + PerSecondCookies;
        }
    }
}
