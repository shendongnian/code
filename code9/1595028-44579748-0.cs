    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[][] toMerge = {
                    new string[] {"School", "Train", "Bag", "Choclate", " ", " "}, 
                    new string[] {"College", " ", " " , "chicken", " ", " "},
                    new string[] {"work", "car", " ", "Burger", " ", " "}
                                      };
                var orderStrings = toMerge.Cast<string[]>().GroupBy(x => x.First()).OrderBy(x => x.Key).Select(x => string.Join(",", x.SelectMany(y => y))).ToArray();
                foreach (string orderString in orderStrings)
                {
                    Console.WriteLine(orderString);
                }
                Console.ReadLine();
            
            }
        }
    }
