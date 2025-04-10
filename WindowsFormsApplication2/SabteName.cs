using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class SabteName : Form
    {
        public SabteName()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("خب به من چه که ربات نیستی");
        }

        private void SabteName_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar a = new System.Globalization.PersianCalendar();
            label11.Text = a.GetYear(DateTime.Now) + " / " + a.GetMonth(DateTime.Now) + " / " + a.GetDayOfMonth(DateTime.Now);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
           progressBar1.Visible = true;
            int max = 100;
            int min = 0;
            progressBar1.Minimum = min;
            progressBar1.Maximum = max;
            for (int i = 0; i < 101; i++)
            {
                progressBar1.Value = i;
            }
            Console.Beep(100, 100);
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Login l = new Login();
            l.ShowDialog();
        }
    }
}
