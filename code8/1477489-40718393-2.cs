    namespace WhatsOn
    {
        using System;
        using System.Threading.Tasks;
        using Flurl;
        using Flurl.Http;
        using Newtonsoft.Json;
        public class Program
        {
            public static void Main()
            {
                TalkToWatson().Wait();
            }
    
            public static async Task TalkToWatson()
            {
                var baseurl = "https://gateway.watsonplatform.net/conversation/api";
                var workspace = "25dfa8a0-0263-471b-8980-317e68c30488";
                var username = "...get your own...";
                var password = "...get your own...";
                var context = null as object;
                var input = Console.ReadLine();
                var message = new { input = new { text = input }, context };
    
                var resp = await baseurl
                    .AppendPathSegments("v1", "workspaces", workspace, "message")
                    .SetQueryParam("version","2016-11-21")
                    .WithBasicAuth(username, password)
                    .AllowAnyHttpStatus()
                    .PostJsonAsync(message);
    
                var json = await resp.Content.ReadAsStringAsync();
    
                var answer = new
                {
                    intents = null as object,
                    entities = null as object,
                    input = null as object,
                    output = new
                    {
                        text = default(string)
                    },
                    context = null as object
                };
    
                answer = JsonConvert.DeserializeAnonymousType(json, answer);
    
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{resp.StatusCode}: {answer?.output?.text}");
    
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(json);
                Console.ResetColor();
            }        
        }
    }
