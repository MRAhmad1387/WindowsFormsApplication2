using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class frmperson : Form
    {
        public frmperson()
        {
            InitializeComponent();
        }
        public void newcode()
        {
            try
            { 
                OleDbDataAdapter da= new OleDbDataAdapter("Select MAX(userid)From tblperson",oleDbConnection1);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            txtperson.Text = (Convert.ToInt32(dataTable.Rows[0].ItemArray[0])+1).ToString();

            }
            catch
            {
                txtperson.Text = "1050";
                
            }
           
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
             
            txtperson.Focus();

            //فراخوانی تابع عدد یوزر
            newcode();

            //اتصال دیتابیس
            OleDbConnection con = new OleDbConnection();
        
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\omidm\\Desktop\\WindowsFormsApplication2\\WindowsFormsApplication2\\bin\\Debug\\Database.accdb";
            //بازکردن دیتابیس
            con.Open();
            //دریافت اطلاعات و ایجاد جدول مجازی
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT userid, fristname, lastname, codemli, tav, tell, addres, img FROM tblperson", con);
            DataTable dataTable = new DataTable();
            //ریختن اطلاعات بصورت فیل به جدول مجازی
            da.Fill(dataTable);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dataTable;
            //بستن اتصال
            con.Close();



            //ساعت 
            System.Globalization.PersianCalendar a = new System.Globalization.PersianCalendar();
            label13.Text = a.GetYear(DateTime.Now) + " / " + a.GetMonth(DateTime.Now) + " / " + a.GetDayOfMonth(DateTime.Now);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files |*.jpg;*.png;";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public static byte[] imagetobyte(Image img)
        {
            ImageConverter convert = new ImageConverter();
            
            return (byte[])convert.ConvertTo(img,typeof(byte[]));
        }
        public void clear()
        {
            txtaddres.Clear();
            txtbirthday.ResetText();
            txtfamily.Clear();
            txtmli.Clear();
            txtname.Clear();
             txtphone.Clear();
            pictureBox1.Image = null;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //اتصال دیتابیس 
              OleDbConnection con   = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\omidm\\Desktop\\WindowsFormsApplication2\\WindowsFormsApplication2\\bin\\Debug\\Database.accdb";
            //نوشتن کویری برای انجام کار
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            
            cmd.CommandText = "INSERT INTO tblperson(userid,fristname,lastname,codemli,tav,tell,addres,img)Values(@userid,@fristname,@lastname,@codemli,@tav,@tell,@addres,@img)";
            cmd.Parameters.AddWithValue("@userid",Convert.ToInt32(txtperson.Text));
            cmd.Parameters.AddWithValue("@fristname", txtname.Text);
            cmd.Parameters.AddWithValue("@lastname",txtfamily.Text);
            cmd.Parameters.AddWithValue("@codemli",txtmli.Text);
            cmd.Parameters.AddWithValue("@tav", txtbirthday.txtDate.Text);
            cmd.Parameters.AddWithValue("@tell",txtphone.Text);
            cmd.Parameters.AddWithValue("@addres",txtaddres.Text);
            
            cmd.Parameters.AddWithValue("@img", imagetobyte(pictureBox1.Image));
            //باز کردن اتصال
            con.Open();
            //اجرای کویری
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                MessageBox.Show("اطلاعات ذخیره شد");

            }
            else
            {
                MessageBox.Show("اطلاعات ذخبره نشد");
            }
            //بستن اتصال
           con.Close();

            //کارهای بعد از دیتابیس
            //پاک کردن اطلاعات در صفحه

            
            clear();



            //فراخوانی تابع فرم لود
            Form2_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmperson_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = new DialogResult();
            if(dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("نهههه");

            }
        }
    }
}
