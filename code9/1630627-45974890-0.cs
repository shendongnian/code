    using System;
    using System.IO;
    using System.Net;    
        
        class Program
        {
            static void Main(string[] args)
            {
              var networkPath = @"//server/share";
              var credentials = new NetworkCredential("username", "password");
              
              using (new NetworkConnection(networkPath, credentials))
              {
                var fileList = Directory.GetFiles(networkPath);
              }
              
              foreach (var file in fileList)
              {
                  Console.WriteLine("{0}", Path.GetFileName(file));
              }          
            }
        }
