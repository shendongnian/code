    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
                List<string> period = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if (inputLine.StartsWith("Period"))
                        {
                            string key = inputLine.Replace("|", "");
                            period = new List<string>();
                            data.Add(key, period);
                        }
                        else
                        {
                            period.Add(inputLine);
                        }
                    }
                }
            }
        }
    }
