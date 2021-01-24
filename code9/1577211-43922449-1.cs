    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                WriteLine(ConsoleColor.Red, "Hello {0},{2} {1} asd", "Name1", "Name2", "Name3");
    
            }
            public static void WriteLine(ConsoleColor c, string value, params object[] prms)
            {
                var regEx = new Regex("{[0-9]*}");
                var matches = regEx.Matches(value);
                int i = 0;
                int j = 0;
                int newLenght = (value.Length - 3 * (prms.Length) + (int)prms.Sum(x=>((string)x).Length));
                var valueArr = value.ToCharArray();
                foreach (Match m in matches)
                {                
                    while (i < value.IndexOf(m.Value) && i< newLenght)
                    {
                        Console.Write(valueArr[i]);
                        i++;
                    }
                    i += m.Value.Length;
                    Console.ForegroundColor = c;
                    Console.Write(prms[j]);
                    Console.ResetColor();
                    j++;
                }
                Console.WriteLine();
            }
        }
    }
