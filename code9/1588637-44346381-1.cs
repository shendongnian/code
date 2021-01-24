    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static void clear()
            {
    
                Thread.Sleep(1500);
                Console.SetCursorPosition(0, 0);
    
            }
    
    
            static void Main(string[] args)
            {
                var client = new WebClient();          
    
                client.DownloadProgressChanged += (o, e) =>
                {
                    Console.Clear();
                    Console.Write(e.ProgressPercentage + "% ");
                    clear();
    
    
                };            
    
                client.DownloadFileAsync(new Uri("http://XXX"), "file");
    
                Console.ReadKey();   
    
            }
        }
    }
