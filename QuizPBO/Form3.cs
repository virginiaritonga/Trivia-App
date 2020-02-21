using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPBO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int number = 1;
            if (radioButton1.Checked && number<6)
            {
                number++;
                Form1 startquiz = new Form1();
                startquiz.Show();
                this.Hide();
            }
            if (radioButton2.Checked)
            {
                Gadgets startquiz = new Gadgets();
                startquiz.Show();
                this.Hide();
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
