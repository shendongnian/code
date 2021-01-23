    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication33
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                obj1.obj1s = doc.Descendants("YEAR").Select(x => new obj1
                {
                    year = (int)x.Attribute("NUMBER"),
                    month = (int)x.Element("MONTH").Attribute("NUMBER")
                }).ToList();
     
            }
        }
        public class obj1
        {
            public static List<obj1> obj1s = new List<obj1>();
            public int year { get; set; }
            public int month { get; set; }
        }
        
    }
