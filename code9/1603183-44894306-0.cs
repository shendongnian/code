    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static List<string[]> temp = new List<string[]>
            {
                // The order of these groups is important
                new string[] { "a", "b", "c" },
                new string[] { "d", "e" },
                new string[] { "f", "g", "h" }
            };
            static void Main(string[] args)
            {
                Recursive(0, new List<string>());
                Console.ReadLine();
            }
            public static void Recursive(int level, List<string> output)
            {
                if (level < temp.Count)
                {
                    foreach (string value in temp[level])
                    {
                        List<string> newList = new List<string>();
                        newList.AddRange(output);
                        newList.Add(value);
                        Recursive(level + 1, newList);
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(",",output));
                }
            }
        }
    }
