    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    
    namespace AzureADTokenApp
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var client = new HttpClient();
                var uri = "https://login.microsoftonline.com/<tenant-name>.onmicrosoft.com/oauth2/token?api-version=1.0";
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("resource", "https://graph.microsoft.com"),
                    new KeyValuePair<string, string>("client_id", "<azure ad client id e.g. 9b864-a5e6-4f0d-b155-1f53a6c78>"),
                    new KeyValuePair<string, string>("client_secret", "<azure ad client secret e.g. MTMiXaO1P9HnhSawdXWmcnuQ="),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "<azure ad user e.g. julius.depulla@example.com>"),
                    new KeyValuePair<string, string>("password", "<azure ad user password e.g. Pa$$word01>"),
                    new KeyValuePair<string, string>("scope", "openid")
                 };
    
                var content = new FormUrlEncodedContent(pairs);
    
                var response = client.PostAsync(uri, content).Result;
    
                string result = string.Empty;
    
                if (response.IsSuccessStatusCode)
                {
    
                    result = response.Content.ReadAsStringAsync().Result;
                }
    
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
