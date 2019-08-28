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
    public partial class Form2 : Form
    {


        MySqlConnection conn = new MySqlConnection("Server=localhost; Database=academy; Uid=root; Pwd=1234");
        MySqlDataAdapter msc;
        MySqlDataAdapter msctwo;



        public Form2()
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


        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

     

        private void button1_Click(object sender, EventArgs e)
        {



            conn.Open();

            string rbdtext = "";

            if (malerB.Checked)
                {
                
                    rbdtext = malerB.Text;
                }
                else if (femalerB.Checked)
                {
                    rbdtext = femalerB.Text;
                }

            string insertQuery = "INSERT INTO user_info(id,name,sex,birth,phone,address,school,subject,payment) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + rbdtext + "','" + dateTimePicker1.Text + "','" + comboBox3.Text + textBox4.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + payLabel.Text + "')";
            
            MySqlCommand sqlCommand = new MySqlCommand(insertQuery, conn);

            try
            {
               
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                 
                    msctwo = new MySqlDataAdapter("select * from user_info", conn);
                    DataSet dds = new DataSet();
                    msctwo.Fill(dds);
                    Sub_View.DataSource = dds.Tables[0];

                    //close.conn
                    this.CloseConnection();
                    MessageBox.Show("회원가입완료");
                }
                else
                {
                    MessageBox.Show("회원가입실패");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }
    

        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open(); //커넥션 오픈

            try
            {
                if (comboBox1.Text=="과목을 선택하세요")  // 콤보박스가 비었을때
                {
                    MessageBox.Show("과목이 선택되지 않았습니다..", "과목선택", MessageBoxButtons.OK, (MessageBoxIcon.Warning)); // 
                    this.CloseConnection();
                    return;
                }

                msc = new MySqlDataAdapter("select * from user_info where subject='" + comboBox1.Text + "'", conn);
                DataSet dds = new DataSet();
                msc.Fill(dds);
                Sub_View.DataSource = dds.Tables[0];
                //close.conn
                this.CloseConnection();
                

            }

            catch (Exception ex)
            {
                MessageBox.Show("에러", ex.ToString(), MessageBoxButtons.OK, (MessageBoxIcon.Hand));

            }
            conn.Close();
        }

        private void payLabel_Click(object sender, EventArgs e)
        {
            if (payLabel.Text == "미납")
            {
                payLabel.Text = "납부";
            }
            else if (payLabel.Text == "납부")
            {
                payLabel.Text = "미납";
            }
        }

        private void Sub_View_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = ((DataTable)Sub_View.DataSource).GetChanges();

            if (changes != null)
            {
                MySqlCommandBuilder mdb = new MySqlCommandBuilder(msc);
                msc.UpdateCommand = mdb.GetUpdateCommand();
                msc.Update(changes);
                ((DataTable)Sub_View.DataSource).AcceptChanges();
            }
            this.Sub_View.Invalidate();
        }

        private void UserinfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.Text = "010";
            textBox4.Text = "";
            textBox5.Text="";
            textBox3.Text = "";
            comboBox2.Text = "과목을 선택하세요";
            payLabel.Text = "미납";
            malerB.Checked = true;

        }


        
    }
}
