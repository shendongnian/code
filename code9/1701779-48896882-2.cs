    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace test1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var lines = File.ReadAllLines(@"C:/temp/TextFile.txt").Select(x => x.Split('/')).FirstOrDefault();
                var words = new Dictionary<string, string>();
    
                for (int i = 0; i < lines.Length - 1; i += 2)
                {
                    words.Add(lines[i], lines[i + 1]);
                }
                
                PrintDictionary(words);
                Console.ReadKey();
            }
    
           static void PrintDictionary(Dictionary<string,string> dict)
           {
               foreach (var kvp in dict)
                {
                    Console.WriteLine(string.Format("{0} - {1}", kvp.Key, kvp.Value));
                }
           }
        }
    }
