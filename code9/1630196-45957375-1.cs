    using Microsoft.AspNetCore.Hosting;
    using Newtonsoft.Json;
    using System.IO;
    
    namespace WebApplication1
    {
        public class Program
        {
            public class GithubPayload
            {
                public string Action { get; set; }  // action
                public string Name { get; set; }    // pull_request.title
            }
            
            public static void Main(string[] args)
            {
                string json = @"{
      ""action"": ""deleted"",
      ""pull_request"": {
                    ""title"": ""Fix button""
      }
            }";
    
                dynamic obj = JsonConvert.DeserializeObject(json);
                
                GithubPayload entity = new GithubPayload();
                entity.Action = obj.action;
                entity.Name = obj.pull_request.title;
    
                ..................
            }
        }
    }
