    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<string> uniqueOddLines = new List<string>();
                List<string> lines = new List<string>();
                string inputLine = "";
                StreamReader reader = new StreamReader(FILENAME);
                int index = 0;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (++index % 2 == 0)
                    {
                        lines.Add(inputLine);
                    }
                    else
                    {
                        if (uniqueOddLines.Contains(inputLine))
                        {
                            lines.Add(string.Format("Rewrite line {0}", index));
                        }
                        else
                        {
                            uniqueOddLines.Add(inputLine);
                            lines.Add(inputLine);
                        }
                    }
                }
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            }
        }
    }
