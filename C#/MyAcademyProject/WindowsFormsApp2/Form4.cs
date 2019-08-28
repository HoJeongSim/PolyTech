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
    public partial class Form4 : Form
    {

        MySqlConnection conn = new MySqlConnection("Server=localhost; Database=academy; Uid=root; Pwd=1234");
        MySqlDataAdapter msc;
        

        string id = "";
        string name = "";
        string school = "";
        string subject = "";

        public Form4()
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

        private void Button1_Click(object sender, EventArgs e)
        {
            conn.Open(); //커넥션 오픈

            try
            {
                if (comboBox1.Text == "과목을 선택하세요")  // 콤보박스가 비었을때
                {
                    MessageBox.Show("과목이 선택되지 않았습니다..", "과목선택", MessageBoxButtons.OK, (MessageBoxIcon.Warning)); 
                    this.CloseConnection();
                    return;
                }

                msc = new MySqlDataAdapter("select * from user_info where subject='" + comboBox1.Text + "'", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                dataGridView1.DataSource = dds.Tables[0];
                
                this.CloseConnection();
                

            }

            catch (Exception ex)
            {
                MessageBox.Show("에러", ex.ToString(), MessageBoxButtons.OK, (MessageBoxIcon.Hand));

            }
            conn.Close();
        }

  
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           
          
         
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            conn.Open();


            id = this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
            name = this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
            school = this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[6].Value.ToString();
            subject = this.dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[7].Value.ToString();

            string atbtext = "";

            if (atdRb.Checked)
            {
                atbtext = atdRb.Text;
            }
            else if (lateRb.Checked)
            {
                atbtext = lateRb.Text;
            }
            else if (absRb.Checked)
            {
                atbtext = absRb.Text;
            }

            string insertQuery = "INSERT INTO user_attend(id,name,school,subject,date,attendance) VALUES('" + id + "','" + name + "','" + school + "','" + subject + "','" + dateTimePicker1.Text + atbtext + "')";
            //MessageBox.Show(insertQuery);
            MessageBox.Show("완료되었습니다.");
            MySqlCommand sqlCommand = new MySqlCommand(insertQuery, conn);

            conn.Close();
        }

        
    }
}
