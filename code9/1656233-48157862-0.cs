    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace CSharp.Console
    {
        public class Program
        {
            // Make HttpClient a static member so it's available for the lifetime of the application.
            private static readonly HttpClient HttpClient = new HttpClient();
    
            public static async Task Main(string[] args)
            {
                string body = await HttpClient.GetStringAsync("http://www.google.com");
                System.Console.WriteLine(body);
                System.Console.ReadLine();
            }
        }
    }
