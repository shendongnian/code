    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace test3
    {
        class Program
        {
    
            static void Main(string[] args)
            {
    
                string createText = System.IO.File.ReadAllText(@"C:\PATH_TO_THE FILE_I_USED\data.txt");
    
                Regex regex = new Regex("(?<=941d3c8a-8d5d-42aa-943e-a07ccaba1629\" >)(.*)(?=<\\/ TD >)",
                    RegexOptions.IgnoreCase
                    | RegexOptions.CultureInvariant
                    | RegexOptions.IgnorePatternWhitespace
                    | RegexOptions.Compiled
                    );
    
                MatchCollection ms = regex.Matches(createText);
    
                foreach (Match match in ms)
                {
                    Console.WriteLine(match);
                }
    
                Console.ReadLine();
            }
    
        }
    }
