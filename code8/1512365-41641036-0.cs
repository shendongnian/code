    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<Root>" +
                    "<Results>" +
                        "<Count>3</Count>" +
                        "<Result1>...properties...</Result1>" +
                        "<Result2>...properties...</Result2>" +
                        "<Result3>...properties...</Result3>" +
                    "</Results>" +
                    "</Root>";
                XElement xResults = XElement.Parse(xml);
                Results results = xResults.Elements("Results").Select(x => new Results() {
                    Count = (int)x.Element("Count"),
                    ResultItems = x.Elements().Where(y => y.Name.LocalName.StartsWith("Result")).Select(y => (string)y).ToList()
                }).FirstOrDefault();
     
            }
     
        }
        public class Results
        {
            
            public int Count { get; set; }
            public List<string> ResultItems { get; set; }
        }
    }
