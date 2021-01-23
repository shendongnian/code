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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                
                XElement addElement = doc.Descendants("myData").Where(x => x.Elements("evt").Where(y => (string)y.Attribute("val") == "open").Count() == 0).FirstOrDefault();
                if (addElement != null)
                {
                    addElement.Add( new XElement("evt", new object[] {
                        new XAttribute("val","closed"),
                        new XAttribute("time","87000")
                    }));
                }
                
            }
        }
    }
