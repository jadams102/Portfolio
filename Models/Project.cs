using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("search/repositories?q=user:joelaphoto&sort=stars&order=asc", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            List<Project> projectList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse["items"].ToString());
            List<Project> topThree = new List<Project> { projectList[0], projectList[1], projectList[2] };
            return topThree;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
