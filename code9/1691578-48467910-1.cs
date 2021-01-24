    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace Oppgave3Lesson1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                WinterJsonModel data = new WinterJsonModel();
                data.ParseFile(FILENAME);
            }
        }
        public class WinterJsonModel
        {
            public static List<WinterJsonModel> samplData = new List<WinterJsonModel>();
            public string fips { get; set; }
            public string state { get; set; }
            public string wfo { get; set; }
            public List<Group> groups = new List<Group>();
            public void ParseFile(string winterBoundsPath)
            {
                WinterJsonModel data = null;
                Group group = null;
                int id = -1;
                using (var reader = new StreamReader(winterBoundsPath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Trim();
                        if (line.Length > 0)
                        {
                            if (line.StartsWith("<FIPS>"))
                            {
                                data = new WinterJsonModel();
                                WinterJsonModel.samplData.Add(data);
                                string[] rawData = line.Split(new char[] {'<', '>'}, StringSplitOptions.RemoveEmptyEntries);
                                fips = rawData[1];
                                state = rawData[3];
                                wfo = rawData[5];
                            }
                            else
                            {
                                decimal[] rawData = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(x => decimal.Parse(x)).ToArray();
                                if (rawData.Count() == 1)
                                {
                                    id = (int)rawData[0];
                                    group = new Group();
                                    group.id = id;
                                }
                                else
                                {
                                    if (group == null)
                                    {
                                        group = new Group();
                                        groups.Add(group);
                                        group.id = -1;
                                    }
                                    group.values.AddRange(rawData);
                                }
                            }
                        }
                    }
                }
            }
        }
        public class Group
        {
            public int id { get; set; }
            public List<decimal> values = new List<decimal>();
        }
    }
