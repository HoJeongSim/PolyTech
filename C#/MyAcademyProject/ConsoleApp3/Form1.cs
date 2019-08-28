using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.StartPosition = FormStartPosition.Manual;
            form4.Location = new Point(300, 200);
            form4.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.StartPosition = FormStartPosition.Manual;
            form3.Location = new Point(300, 200);
            form3.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(300, 200);
            form2.Show();
        }
    }
}
