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
                var ignoreTls = true;
    
                using (var httpClientHandler = new HttpClientHandler())
                {
                    if (ignoreTls)
                    {
                        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    }
    
                    using (var client = new HttpClient(httpClientHandler))
                    {
                        using (HttpResponseMessage response = await client.GetAsync("https://test.com/get"))
                        {
                            Console.WriteLine(response.StatusCode);
                            var responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseContent);
                        }
    
                        using (var httpContent = new StringContent("{ \"id\": \"4\" }", Encoding.UTF8, "application/json"))
                        {
                            var request = new HttpRequestMessage(HttpMethod.Post, "http://test.com/api/users")
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
