    using System;
    using System.Net;
    
    static class Program
    {
        public static void Main()
        {
            WebClient wc = new WebClient();
            var proxies = wc.DownloadString(@"http://proxy-ip-list.com/download/free-proxy-list.txt");
    
            Console.WriteLine("http://" + proxies.Split(';')[5].Trim());
    
            Console.ReadLine();
        }
    }
