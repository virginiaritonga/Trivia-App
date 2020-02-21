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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form3 pickquiz = new Form3();
            pickquiz.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Highscore scores = new Highscore();
            scores.Show();
        }
    }
}
