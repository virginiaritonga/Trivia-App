using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;




namespace QuizPBO
{
    class Question
    {

        public virtual List<QuestionSet> GetQuestion()
        {
            var client = new RestClient();
            var request = new RestRequest("https://opentdb.com/api.php?amount=4&category=18&type=multiple", Method.GET);
            IRestResponse response = client.Execute(request);
            Wrapper results = new Wrapper();
            results = JsonConvert.DeserializeObject<Wrapper>(response.Content);
            List<QuestionSet> questionSets = new List<QuestionSet>();
            for(int i=0;i<4;i++)
            {
                questionSets.Add(results.QuestionSet[i]);
            }
            return questionSets;

        }


    }
      
    class Wrapper
    {
        [JsonProperty("results")]
        public List<QuestionSet> QuestionSet { get; set; }
        
    }

    class QuestionSet
    {
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("correct_answer")]
        public string Answer { get; set; }
        [JsonProperty("incorrect_answers")]
        public List<string> Incorrect { get; set; }
    }
}
