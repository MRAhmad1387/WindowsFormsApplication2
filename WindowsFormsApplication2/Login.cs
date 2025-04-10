using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using WindowsFormsApplication2;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblWatch.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second;
                
        }

        private void lblTarikh_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            System.Globalization.PersianCalendar a = new System.Globalization.PersianCalendar();
            lblTarikh.Text = a.GetYear(DateTime.Now) + " / " + a.GetMonth(DateTime.Now) + " / " + a.GetDayOfMonth(DateTime.Now);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = oleDbConnection1;
              
                cmd.CommandText = "Select UserId,Username,pass From tbllogin where Username='" + textBox1.Text + "'and pass='" + textBox2.Text + "'";
                
                OleDbDataReader da = cmd.ExecuteReader();
               
                if (da.Read())
                {
                    if(radioButton1.Checked == true)
                    { 
                        ClassUser.Username = da[1].ToString();
                    MessageBox.Show( "مدیر  :  " + ClassUser.Username+ " خوش آمدید ");

                    new manager().ShowDialog();
                    this.Hide();

                    }
                    else if(radioButton2.Checked == true)
                    {
                        ClassUser.Username = da[1].ToString();
                        MessageBox.Show("کاربر  :  "+ClassUser.Username + " خوش آمدید ");
                        new User().ShowDialog();
                        this.Hide();
                    }
                  

                }
                else
                {
                    MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
                    textBox1.Text = textBox2.Text = "";
                    textBox1.Focus();
                }

            }
            else
            {
                MessageBox.Show("مقادیر را وارد کنید","توجه",MessageBoxButtons.OK);
            }
            oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SabteName a = new SabteName();
            a.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new SabteName().ShowDialog();
        }
    }
}
