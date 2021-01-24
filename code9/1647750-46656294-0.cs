    using System;
    
    namespace ConsoleApp1
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Enter value to square or X to exit");
    
                    var line = Console.ReadLine();
                    if (line == null)
                        continue;
    
                    if (line.Trim().Equals("X", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Exitting ...");
                        break;
                    }
    
                    int result;
    
                    if (!int.TryParse(line, out result))
                        continue;
    
                    Console.WriteLine(result * result);
                }
            }
        }
    }
