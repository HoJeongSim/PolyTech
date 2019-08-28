using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        private MySqlDataAdapter mySqlDataAdapter;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(300, 200);
            form2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.StartPosition = FormStartPosition.Manual;
            form3.Location = new Point(300, 200);
            form3.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.StartPosition = FormStartPosition.Manual;
            form4.Location = new Point(300, 200);
            form4.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void CreateTable1()
        {
            try
            {
                string createQuery = "create table user_info(id nvarchar(50) NOT NULL primary key, name nvarchar(50) NOT NULL, sex nvarchar(50) NOT NULL, birth nvarchar(50) NOT NULL, " +
                    "phone nvarchar(50) NOT NULL, address nvarchar(50) NOT NULL, school nvarchar(50) NOT NULL, subject nvarchar(50) NOT NULL, payment nvarchar(50) NOT NULL) ";
                MySqlCommand create = new MySqlCommand(createQuery, conn);
                create.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void CreateTable2()
        {
            try
            {
                string createQuery = "create table user_attend( id nvarchar(50) NOT NULL primary key,name nvarchar(50) not null,school nvarchar(50) not null,subject nvarchar(50) not null," +
                    "date nvarchar(50) not null,attendance nvarchar(50) not null); ";
                MySqlCommand create = new MySqlCommand(createQuery, conn);
                create.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateTable1();
            CreateTable2();
        }
    }
}
