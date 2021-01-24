    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                WriteLine(ConsoleColor.Red, "Hello {0},{2} {1} asd {1} {0} {2}", "Name1", "Name2", "Name3");
    
            }
            public static void WriteLine(ConsoleColor c, string value, params object[] prms)
            {
                var regEx = new Regex("{[0-9]*}");
                var matches = regEx.Matches(value);
                int i = 0;
                int newLenght = (value.Length - 3 * (prms.Length) + (int)prms.Sum(x => ((string)x).Length));
                var valueArr = value.ToCharArray();
                foreach (Match m in matches)
                {
                    while (i < m.Index && i < valueArr.Length)
                    {
                        Console.Write(valueArr[i]);
                        i++;
                    }
                    i += m.Value.Length;
                    Console.ForegroundColor = c;
                    Console.Write(prms[int.Parse(m.Value.Substring(1,1))]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
