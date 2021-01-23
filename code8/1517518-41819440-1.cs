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
                XElement title = doc
                   .Descendants("div")
                   .Where(x => (string)x.Attribute("TYPE") == "TITLE")
                   .FirstOrDefault();
                title.Add(new XElement("fptr", new object[] {
                   new XElement("area", new object[] {
                       new XAttribute("BETYPE","IDREF"),
                       new XAttribute("FILEID","ALTO0011"),
                       new XAttribute("BEGIN","P11_TB3")
                   })
                }));
            }
        }
    }
