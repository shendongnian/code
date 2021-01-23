    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    namespace Select_specific_lines_in_an_array
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string line = "";
                int count = 0;
                List<List<string>> testlist = new List<List<string>>();
                List<string> templist = new List<string>();
                System.IO.StreamReader file = new System.IO.StreamReader(FILENAME);
                string pattern = @"^(?'letter'[A-Z]+)(?'number'\d+)$";
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        Match match = Regex.Match(line, pattern);
                        if (match.Success)
                        {
                            Console.WriteLine("Letter : '{0}', Number : '{1}'", match.Groups["letter"], match.Groups["number"]);
                            templist.Add(line);
                            if (templist.Count == 2)
                            {
                                testlist.Add(templist);
                                templist = new List<string>();
                            }
                        }
                    }
                    count = count + 1;
                }
                file.Close();
                Console.ReadKey();
            }
        }
    }
