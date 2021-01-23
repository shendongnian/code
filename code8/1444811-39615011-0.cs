    using ConsoleApplication1.Helpers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        const string userName = "user@user.com";
        const string password = "Password01!";
        const string apiBaseUri = "http://localhost/WebAPITest";
        
        private static async void GetAPIToken()
        {
           string responseJson =  await ResponseAsStringAsync(string.Format("{0}/token", apiBaseUri),
                new[]
                {
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("grant_type", "password"),
                });
            var jObject = JObject.Parse(responseJson);
            string token = jObject.GetValue("access_token").ToString();            
        }
        public static async Task<string> ResponseAsStringAsync(string url, IEnumerable<KeyValuePair<string, string>> postData)
        {
            string responseString = string.Empty;
            var uri = new Uri(url);
            using (var client = new HttpClient())
            using (var content = new FormUrlEncodedContent(postData))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                HttpResponseMessage response = await client.PostAsync(uri, content);
                responseString = await response.Content.ReadAsStringAsync();
            }
            return responseString;
        }
        static void Main(string[] args)
        {
            GetAPIToken();           
            Console.ReadKey();
        }
       
    }
    
    }
