    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication74
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                            "\"DESCRIPTION1\",\"8, 5/8 X 6.4MM\",\"STRING\",\"filename001.pdf\",\"2016-09-19\",\"1\"\n" +
                            "\"DESCRIPTION2\",\"12, 3/4 X 6.4MM\",\"STRING\",\"filename001.pdf\",\"2016-09-19\",\"1\"\n" +
                            "\"DESCRIPTION3\",\"12, 3/4 X 6.4MM\",\"STRING\",\"filename001.pdf\",\"2016-09-19\",\"1\"\n" +
                            "\"another description 20# gw\",\"1\",\"388015\",\"Scan123.pdf\",\"2015-10-24\",\"1\"\n" +
                            "\"another description 20# gw\",\"3\",\"385902\",\"Scan456.pdf\",\"2015-04-14\",\"1\"\n" +
                            "\"STRINGVAL1\",\"273.10 X 9.27 X 6000\",\"45032-01\",\"KHJDWNEJWKFD9101529.pdf\",\"2012-02-03\",\"1\"\n" +
                            "\"STRINGVAL2\",\"273.10 X 21.44 X 6000\",\"7-09372\",\"DJSWH68767681540.pdf\",\"2017-02-03\",\"1\"\n";
            
                string pattern = "\\\"\\s*,\\s*\\\"";
                string inputline = "";
                StringReader reader = new StringReader(input);
                XElement root = new XElement("Root");
                while ((inputline = reader.ReadLine()) != null)
                {
                    string[] splitLine = Regex.Split(inputline,pattern);
                    Item newItem = new Item() {
                        description = splitLine[0].Replace("\"",""),
                        length = splitLine[1],
                        type = splitLine[2],
                        filename = splitLine[3],
                        date = DateTime.Parse(splitLine[4]),
                        authorized = splitLine[5].Replace("\"", "") == "1" ? true : false
                    };
                    Item.items.Add(newItem);
                }
                foreach(var year in Item.items.GroupBy(x => x.date.Year).OrderBy(x => x.Key))
                {
                    XElement newYear = new XElement("_" + year.Key.ToString());
                    root.Add(newYear);
                    foreach(var month in year.GroupBy(x => x.date.Month).OrderBy(x => x.Key))
                    {
                        XElement newMonth = new XElement("_" + month.Key.ToString());
                        newYear.Add(newMonth);
                        newMonth.Add(
                            month.OrderBy(x => x.date).Select(x => new XElement(
                                x.filename,
                                string.Join("\r\n", new object[] {
                                    x.description,
                                    x.length,
                                    x.type,
                                    x.date.ToString(),
                                    x.authorized.ToString()
                                }).ToList()
                        )));
                    }
                }
            }
        }
        public class Item
        {
            public static List<Item> items = new List<Item>();
            public string description { get; set; }
            public string length { get; set; }
            public string type { get; set; }
            public string filename { get; set; }
            public DateTime date { get; set; }
            public Boolean authorized { get; set; }
        }
    }
