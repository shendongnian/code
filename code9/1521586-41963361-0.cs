    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IDictionary<string,string> dict = new Dictionary<string,string>() {
                    {"subfield", "hi"},
                    {"subfield2", "Hello"}
                };
     
                string header = "<?xml version=\"1.0\"?><field></field>";
                XDocument doc = XDocument.Parse(header);
                XElement field = (XElement)doc.FirstNode;
                foreach(string key in dict.Keys)
                {
                    field.Add(new XElement(key, dict[key]));
                }
            }
        }
    }
