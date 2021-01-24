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
                Header header = new Header(FILENAME);
            }
        }
        public class Header
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            public Header(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    string[] inputArray = inputLine.Split(new char[] { '=' }).ToArray();
                    dict.Add(inputArray[0].Trim(), inputArray[1].Trim());
                }
            }
        }
    }
