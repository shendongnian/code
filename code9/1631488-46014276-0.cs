    using System;
    using System.Net.Http;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "https://api.nasa.gov/planetary/earth/imagery?lon=100.75&lat=1.5&date=2014-02-01&cloud_score=True&api_key=DEMO_KEY";
                Uri theUri = new Uri(url);
    
                string method = theUri.Segments[theUri.Segments.Length - 1];
    
                Console.WriteLine("Method: {method}");
    
                var qa = theUri.ParseQueryString();
    
                foreach (string item in qa.AllKeys)
                {
                    Console.WriteLine($"key: {item}, value: {qa[item]}");
                }
    
                Console.ReadKey();
            }
        }
    }
