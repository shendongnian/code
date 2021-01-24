    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Console.WriteLine("Hello {{1}} {0}", "Henry");
                WriteLine(ConsoleColor.Red, "Hello {0},{2} {1} asd {1} {0} {2}", "Name1", "Name2", "Name3");
                WriteLine(ConsoleColor.Red, "Hello {{1}} {0}", "Henry");
                Console.WriteLine("Hello {{1}} {0}", "Henry","David");
                WriteLine(ConsoleColor.Green,"Hello {{1}} {0}", "Henry", "David");
                try
                {
                    Console.WriteLine("Hello {{1}} {1} {0}", "Henry");
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
    
                try
                {
                    WriteLine(ConsoleColor.Red, "Hello {{1}} {1} {0}", "Henry");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
    
            }
            public static void WriteLine(ConsoleColor c, string value, params object[] prms)
            {
                var regEx = new Regex("{[0-9]+}");
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
    
                    if (valueArr[i].Equals('{') && i+m.Value.Length< valueArr.Length && valueArr[i + m.Value.Length].Equals('}'))
                    {
                        i += m.Value.Length;
                        Console.Write(m.Value.Trim('{', '}'));
                    }
                    else if (int.Parse(m.Value.Trim('{', '}')) < prms.Length)
                    {
                        i += m.Value.Length;
                        Console.ForegroundColor = c;
                        Console.Write(prms[int.Parse(m.Value.Trim('{', '}'))]);
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new Exception("Index must be greater than or equal to zero and less than the size of the argument list.");
                    }
                }
                while (i < valueArr.Length)
                {
                    Console.Write(valueArr[i]);
                    i++;
                }
                Console.WriteLine();
            }
        }
    }
