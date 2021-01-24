    using Microsoft.Owin.Hosting;
    using System;
    
    namespace WebApiDocker
    {
        class Program
        {
            static void Main(string[] args)
            {
                string baseAddress = "http://*:80/";
    
                using (WebApp.Start<Startup>(url: baseAddress))
                {
                    Thread.Sleep(Timeout.Infinite);
                }
            }
        }
    }
