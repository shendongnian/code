    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication14
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string name = "P:class1.clsPerson.isAlive";
                XElement person = doc.Descendants("member").Where(x => (string)x.Attribute("name") == name).FirstOrDefault();
                person.Add(new object[] {
                    new XElement("Description", "Whether the object is alive or dead"),
                    new XElement("StandardValue", false)
                });
            }
        }
     
    }
