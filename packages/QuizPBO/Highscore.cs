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
    public partial class Highscore : Form
    {
        private List<int> scoreList;
        private List<string> nameList;
        private string scores, users;
        int topScore = 0;
        int index = 0;

        public Highscore()
        {
            InitializeComponent();
            TambahData();
            Scoreboard();

        }

        public void TambahData()
        {
            using (var db = new ScoreModel())
            {
                scoreList = new List<int>();
                nameList = new List<string>();
                var query = from user in db.Tables select user;
                foreach (var item in query)
                {
                    scoreList.Add(item.Score);
                    nameList.Add(item.Name);
                }
            } 
        }

        private void LabelName_Click(object sender, EventArgs e)
        {

        }

        private void LabelScore_Click(object sender, EventArgs e)
        {

        }

        public void Scoreboard()
        {
            int x = scoreList.Count();
            for(int i = 0; i<x; i++)
            {
                for (int j = 0; j < scoreList.Count(); j++)
                {
                    if (scoreList[j] > topScore)
                    {
                        topScore = scoreList[j];
                        index = j;
                    }
                }
                users += nameList[index] + "\n";
                nameList.RemoveAt(index);
                scores += Convert.ToString(topScore) + "\n";
                scoreList.RemoveAt(index);
                topScore = 0;
            }
            labelScore.Text = scores;
            labelName.Text = users;
            
        }
    }
}
