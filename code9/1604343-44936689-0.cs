    using System;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Net.Http;
    using System.Web;
    using System.IO;
    
    namespace CSHttpClientSample
    {
        static class Program
        {
            static void Main()
            {
                MakeRequest();
                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            }
    
            static async void MakeRequest()
            {
                var client = new HttpClient();
                var queryString = "";
    
                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "YOUR KEY IN HERE");
    
                var json = "{  \"documents\": [    {      \"language\": \"en\",      \"id\": \"1\",      \"text\": \"I had a wonderful experience\"    }, {      \"language\": \"en\",      \"id\": \"2\",      \"text\": \"It was an Ugly picture\"    }  ]}";
    
    
                var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?" + queryString;
    
                HttpResponseMessage response;
    
                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes(json);
    
                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);
    
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
    
            }
        }
    }
