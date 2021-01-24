    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CoreFxHttpClientHandlerTest
    {
        public class Program
        {
            private static void Main(string[] args)
            {            
            }
    
            public static async Task<bool> Run()
            {
                var ignoreTlc = true;
    
                using (var httpClientHandler = new HttpClientHandler())
                {
                    if (ignoreTlc)
                    {
                        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    }
    
                    using (var client = new HttpClient(httpClientHandler))
                    {
                        using (HttpResponseMessage response = await client.GetAsync("https://hub.quobject.io/get"))
                        {
                            Console.WriteLine(response.StatusCode);
                            var responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseContent);
                        }
    
                        using (var httpContent = new StringContent("{ \"id\": \"4\" }", Encoding.UTF8, "application/json"))
                        {
                            var request = new HttpRequestMessage(HttpMethod.Post, "http://hub.quobject.io/api/users")
                            {
                                Content = httpContent
                            };
                            httpContent.Headers.Add("Cookie", "a:e");
    
                            using (HttpResponseMessage response = await client.SendAsync(request))
                            {
                                Console.WriteLine(response.StatusCode);
                                var responseContent = await response.Content.ReadAsStringAsync();
                                Console.WriteLine(responseContent);
                            }
                        }
                    }
                }
    
                return true;
            }
        }
    }
