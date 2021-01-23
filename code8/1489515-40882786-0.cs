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
                XElement menu = doc.Element("Menu");
                var results = menu.Descendants("Menu").Select(x => new {
                    textField = (string)x.Attribute("TextField"),
                    menuID = (int)x.Attribute("MenuID")
                }).ToList();
            }
        }
    }
