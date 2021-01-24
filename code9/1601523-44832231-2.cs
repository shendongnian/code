    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    namespace SOTest
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                using (RestService rs = new RestService())
                {
                    var result = rs.GetRequest<Product>(@"http://eshop.sambacentrum.tumam.cz/api/byznys/GetProduct?code=sup100").Result;
                    Console.WriteLine(result.Name);
                }
            
                Console.ReadKey();
            }
        }
        public class Product
        {
            public string Amount { get; set; }
            public string Code { get; set; }
            public string CodeEAN { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string PriceWithTax { get; set; }
            public string Text { get; set; }
        }
        public class RestService : IDisposable
        {
            private bool _disposed = false;
            private HttpClient _client;
            public RestService()
            {
                _client = new HttpClient();
                _client.Timeout = TimeSpan.FromSeconds(60);
            }
            public async Task<T> GetRequest<T>(string queryURL)
            {
                T result = default(T);
                using (HttpResponseMessage response = _client.GetAsync(queryURL).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        using (HttpContent content = response.Content)
                        {
                            result = await content.ReadAsAsync<T>();
                        }
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }
                }
                return result;
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        if (_client != null)
                        {
                            _client.Dispose();
                        }
                    }
                    _disposed = true;
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
