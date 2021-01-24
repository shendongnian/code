    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace TestClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy($"http://localhost:8000", false),
                    UseProxy = true,
                };
    
                var client = new System.Net.Http.HttpClient(handler);
    
                var t  = Task.Run(() => GetDataAsync(client, "http://google.com/"));
                t.Wait();
                var result = t.Result;
            }
    
            static async Task<string> GetDataAsync(System.Net.Http.HttpClient client, string path)
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
