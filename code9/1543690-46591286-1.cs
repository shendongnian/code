    using System;
    using System.Net.Http;
    using System.Runtime.InteropServices;
    
    namespace netcurl
    {
        class Program
        {
            static void Main(string[] args)
            {
                var url = "https://localhost:5001/.well-known/openid-configuration";
                var handler = new HttpClientHandler();
                using (var httpClient = new HttpClient(handler))
                {
                    // Only do this for testing and potentially on linux/mac machines
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && IsTestUrl(url))
                    {
                        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    }
                    
                    var output = httpClient.GetStringAsync(url).Result;
                    
                    Console.WriteLine(output);
                }
            }
    
            static  bool IsTestUrl(string url) => url.Contains("localhost");
        }
    }
