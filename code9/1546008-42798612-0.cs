    using System;
    using System.Collections.Generic;
    using Flurl.Http;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var httpResponse = "https://jsonplaceholder.typicode.com/posts"
                                .GetJsonAsync<List<JsonStorage>>();
                httpResponse.Wait();
                var results = httpResponse.Result;
                foreach(var result in results)
                {
                    Console.WriteLine($"title: {result.title}, body: {result.body}");
                }
                Console.ReadLine();
             }    
        }
        class JsonStorage
        {
            public string userId { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }
    }
