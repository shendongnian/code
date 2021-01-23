    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace ScrapCSConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Host = "example.com";
                Task<string> task = client.GetStringAsync("https://serverName/clearprofile.ashx");
                task.Wait();
                Console.WriteLine(task.Result);
            }
        }
    }
