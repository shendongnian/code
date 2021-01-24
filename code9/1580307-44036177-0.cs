    using System;
    using System.Text.RegularExpressions;
    using System.Net;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                WebClient wc = new WebClient();
                var proxies = wc.DownloadString(@"http://proxy-ip-list.com/download/free-proxy-list.txt");
                
                Regex regex = new Regex(@"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{1,5}");
                
                Console.WriteLine("http://" + match.Value);
            }
        }
    }
