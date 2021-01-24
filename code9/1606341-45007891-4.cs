    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace ConsoleApp5
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(GetValueAsync("GBP").Result);
                Console.WriteLine(GetValueAsync("USD").Result);
                Console.WriteLine(GetValueAsync("RUB").Result);
            }
            public static async Task<string> GetValueAsync(string curr)
            {
                using (HttpClient client = new HttpClient())
                {
                    var responseString = await client.GetStringAsync("https://blockchain.info/tobtc?currency="+curr+"&value=1");
                    return responseString;
                }
            }
        }
    }
