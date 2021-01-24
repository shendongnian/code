    using System;
    using System.Xml;
    using System.Xml.Linq;
                    
    public class Program
    {
        public static void Main()
        {
            var s = "<link href='aaa' />";
            var doc = XDocument.Parse(s);
            var link = doc.Element("link");
            var href = link.Attribute("href");
            href.Value = "bbb";
            s = doc.ToString();
            Console.WriteLine(s);
        }
    }
