    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace Oppgave3Lesson1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Data data = new Data();
                data.ParseFile(FILENAME);
            }
        }
        public class Data
        {
            public static List<Data> samplData = new List<Data>();
            public string fips { get; set; }
            public string state { get; set; }
            public string wfo { get; set; }
            public List<decimal> values = new List<decimal>();
            public string pattern = @"\<FIPS\>(?'fips'\d+)\<STATE\>(?'state'[^\<]+)\<WFO\>(?'wfo'\w+)";
            public void ParseFile(string filename)
            {
                Data data = null;
                StreamReader reader = new StreamReader(filename);
                string input = "";
                while ((input = reader.ReadLine()) != null)
                {
                    input = input.Trim();
                    if (input.Length > 0)
                    {
                        if (input.StartsWith("<FIPS>"))
                        {
                            data = new Data();
                            Data.samplData.Add(data);
                            Match match = Regex.Match(input, pattern, RegexOptions.Multiline);
                            fips = match.Groups["fips"].Value;
                            state = match.Groups["state"].Value;
                            wfo = match.Groups["wfo"].Value;
                        }
                        else
                        {
                            data.values.AddRange(input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(x => decimal.Parse(x))); 
                        }
                    }
                }
            }
        }
     
    }
