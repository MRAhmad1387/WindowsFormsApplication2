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
    public partial class Gift : Form
    {
        public Gift()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("از پیج رسمی ما دیدن کن");
            MessageBox.Show("اگه دیدن نکنی شرک میاد تو خوابت");
            this.Close();
        }
    }
}
