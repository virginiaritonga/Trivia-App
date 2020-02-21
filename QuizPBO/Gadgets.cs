using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace QuizPBO
{
    public partial class Gadgets : Form
    {

        int number = 1;
        int i;
        int score = 0;
        string username;
       

        public Gadgets()
        {
            InitializeComponent();
            button1.Enabled = true;
           
        }

       
        private void setButtonText(string answer, string incorrect1, string incorrect2, string incorrect3)
        {

            Random random = new Random();
            i = random.Next(1, 4);
            if (i == 1)
            {
                radioButton1.Text = answer;
                radioButton2.Text = incorrect1;
                radioButton3.Text = incorrect2;
                radioButton4.Text = incorrect3;
            }
            else if (i == 2)
            {
                radioButton1.Text = incorrect1;
                radioButton2.Text = answer;
                radioButton3.Text = incorrect2;
                radioButton4.Text = incorrect3;
            }
            else if (i == 3)
            {
                radioButton1.Text = incorrect1;
                radioButton2.Text = answer;
                radioButton3.Text = incorrect2;
                radioButton4.Text = incorrect3;
            }
            else
            {
                radioButton1.Text = incorrect1;
                radioButton2.Text = answer;
                radioButton3.Text = incorrect2;
                radioButton4.Text = incorrect3;
            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            username = textboxName.Text;
            newQuestion();
           

        }

        private void newQuestion()
        {
            button1.Visible = false;
            textboxName.Visible = false;
            richTextBox1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            button5.Visible = true;
            GadgetsQuestions question = new GadgetsQuestions();
            List<QuestionSet> questionSets = question.GetQuestion();
            string answer = questionSets[0].Answer;
            string incorrect1 = questionSets[0].Incorrect[0];
            string incorrect2 = questionSets[0].Incorrect[1];
            string incorrect3 = questionSets[0].Incorrect[2];
            richTextBox1.Text = questionSets[0].Question;
            setButtonText(answer, incorrect1, incorrect2, incorrect3);


        }

        private void Button5_Click(object sender, EventArgs e)
        {

            number++;

            if (i == 1 && radioButton1.Checked)
            {
                MessageBox.Show("Correct!");
                score++;
            }
            else if (i == 2 && radioButton2.Checked)
            {
                MessageBox.Show("Correct!");
                score++;
            }
            else if (i == 3 && radioButton3.Checked)
            {
                MessageBox.Show("Correct!");
                score++;
            }
            else if (i == 4 && radioButton4.Checked)
            {
                MessageBox.Show("Correct!");
                score++;
            }
            else
            {
                MessageBox.Show("Incorrect!");

            }

            newQuestion();

            if (number > 5)
            {
                this.Close();
                MessageBox.Show("Finish! Your Score is "  + score.ToString());
                using (var db = new ScoreModel())
                {
                    Table User = new Table
                    {
                        Score = score,
                        Name = username,
                    };
                    db.Tables.Add(User);
                    db.SaveChanges();

                }
                Form2 form = new Form2();
                form.Closed += (s, args) => this.Close();
                form.Show();
                this.Hide();
            }


        }

        

    }
    }


