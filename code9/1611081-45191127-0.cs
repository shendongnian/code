    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<data> logs = new List<data>();
                var path=Path.Combine(Environment.CurrentDirectory+@"\file.txt");
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                   while((line = sr.ReadLine()) != null)
                   {
                     
                       var log = Regex.Split(line, "     ");
                       logs.Add(new data { LogDate=DateTime.Parse(log[0]),Operation=log[1]});
                   }
                }
                // here you can use linq to get the data you want from logs list
                // end of main 
            }
            
            public class data
            {
                public DateTime LogDate { get; set; }
                public string Operation { get; set; }
            }
            // end of class
        }
        
    }
