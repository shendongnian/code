    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Rect.rectangles = doc.Descendants().Where(x => x.Name.LocalName == "rect").Select(x => new Rect() {
                    style = Rect.GetStyle((string)x.Attribute("style")),
                    id = (string)x.Attribute("id"),
                    width = (double)x.Attribute("width"),
                    height = (double)x.Attribute("width"),
                    x = (double?)x.Attribute("width"),
                    y = (double?)x.Attribute("width")
                }).ToList();
            }
        }
        public class Rect
        {
            public static List<Rect> rectangles { get; set; }
            public Dictionary<string,string> style { get;set;}
            public string id { get; set; }
            public double width { get; set; }
            public double height { get; set; }
            public double? x { get; set; }
            public double? y { get; set; }
            public static Dictionary<string,string> GetStyle(string styles)
            {
                string pattern = @"(?'name'[^:]+):(?'value'.*)";
                string[] splitArray = styles.Split(new char[] {';'});
                Dictionary<string, string> style = splitArray.Select(x => Regex.Match(x, pattern))
                    .GroupBy(x => x.Groups["name"].Value, y => y.Groups["value"].Value)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                return style;
            }
        }
    }
