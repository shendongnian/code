    using System;
    using System.IO;
    
    namespace Test
    {
        public class Program
        {
            static void Main(string[] args)
            {
                string pathdata = @"\\192.168.1.27\Temp\";
    
                var d = new DirectoryInfo(pathdata);
                var files = d.GetFiles("*.pdf");
    
                foreach (var filename in files)
                {
                    Console.WriteLine(pathdata + filename.Name + ".pdf");
                }
    
                Console.ReadLine();
            }
        }
    }
