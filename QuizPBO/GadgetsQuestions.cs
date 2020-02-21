using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace QuizPBO
{
    class GadgetsQuestions : Question
    {
        public override List<QuestionSet> GetQuestion()
        {
            
            var client = new RestClient();
            var request = new RestRequest("https://opentdb.com/api.php?amount=5&category=30&type=multiple", Method.GET);
            IRestResponse response = client.Execute(request);
            Wrapper results = new Wrapper();
            results = JsonConvert.DeserializeObject<Wrapper>(response.Content);
            List<QuestionSet> questionSets = new List<QuestionSet>();
            for (int i = 0; i < 4; i++)
            {
                questionSets.Add(results.QuestionSet[i]);
            }
            return questionSets;

        }
    }
}
