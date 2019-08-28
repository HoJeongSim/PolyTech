using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {

        MySqlConnection conn = new MySqlConnection("Server=localhost; Database=academy; Uid=root; Pwd=1234");
        MySqlDataAdapter msc;
        MySqlDataAdapter msctwo;

        public Form3()
        {
            InitializeComponent();
        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("서버에 연결할 수 없습니다. 관리자에게 문의하세요.", "서버에러", MessageBoxButtons.OK, (MessageBoxIcon.Error));
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }


        private bool CloseConnection()
        {
            try
            {

                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private void Form3_Load(object sender, EventArgs e)
        {



            if (this.OpenConnection() == true)

            {
                msc = new MySqlDataAdapter("select * from user_info", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                dataGridView2.DataSource = dds.Tables[0];
                //close.conntecton
                this.CloseConnection();

            }
       
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            conn.Open(); //커넥션 오픈

            try
            {
                if (comboBox1.Text == "과목을 선택하세요")  // 콤보박스가 비었을때
                {
                    MessageBox.Show("과목이 선택되지 않았습니다..", "과목선택", MessageBoxButtons.OK, (MessageBoxIcon.Warning)); // 
                    this.CloseConnection();
                    return;
                }

                msc = new MySqlDataAdapter("select * from user_info where subject='" + comboBox1.Text + "'", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                dataGridView1.DataSource = dds.Tables[0];
                //close.conn
                this.CloseConnection();
                

            }

            catch (Exception ex)
            {
                MessageBox.Show("에러", ex.ToString(), MessageBoxButtons.OK, (MessageBoxIcon.Hand));

            }
            conn.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            conn.Open(); //커넥션 오픈



            try
            {


                msc = new MySqlDataAdapter("select * from user_info where payment= '미납'", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                dataGridView2.DataSource = dds.Tables[0];
                //close.conn
                this.CloseConnection();
                

            }

            catch (Exception ex)
            {
                MessageBox.Show("에러", ex.ToString(), MessageBoxButtons.OK, (MessageBoxIcon.Hand));

            }
            conn.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            conn.Open(); //커넥션 오픈

            try
            {

                msc = new MySqlDataAdapter("select * from user_info where payment= '납부'", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                dataGridView2.DataSource = dds.Tables[0];
                //close.conn
                this.CloseConnection();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("에러", ex.ToString(), MessageBoxButtons.OK, (MessageBoxIcon.Hand));

            }
            conn.Close();
        }

        private void Button3_Click(object sender, EventArgs e)

        {
            if (this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[8].Value.ToString() == "미납")
            {
                   dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[8].Value = "납부";
            }
            else if(this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[8].Value.ToString() == "납부")
            {
                MessageBox.Show("이미 납부 하였습니다.");
            }

            conn.Open(); //커넥션 오픈



            try
            {

                
                msc = new MySqlDataAdapter("update user_info set payment='납부' where id='this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString()'", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                dataGridView2.DataSource = dds.Tables[0];
                //close.conn
                this.CloseConnection();
                

            }

            catch (Exception ex)
            {
                MessageBox.Show("정상적으로 납부하지 못했습니다.", ex.ToString(), MessageBoxButtons.OK, (MessageBoxIcon.Hand));

            }
            conn.Close();



        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
