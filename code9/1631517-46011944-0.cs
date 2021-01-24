    using System;
    using System.Net.Http;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                        
                    var response = httpClient.GetAsync("http://msystemtest.msystem.co/api/Users?userId=test&pass=1").Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    Console.ReadKey();
                }
            }
        }
    }
