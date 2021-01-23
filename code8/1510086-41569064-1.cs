    using System;
    using System.IO;
    using System.Net;
    
    namespace ScrapCSConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.co.uk");
    
                request.Host = "example.com";
    
                HttpStatusCode code;
                string responseBody = String.Empty;
                
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        code = response.StatusCode;
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException webEx)
                {
                    using (HttpWebResponse response = (HttpWebResponse)webEx.Response)
                    {
                        code = response.StatusCode;
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
    
                Console.WriteLine($"Status: {code}");
                Console.WriteLine(responseBody);
            }
        }
    }
