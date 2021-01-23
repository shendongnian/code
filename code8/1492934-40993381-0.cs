    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement menu = doc.Descendants().Where(x => (string)x.Attribute("TextField") == "Menu").FirstOrDefault();
                foreach (XElement element in menu.Elements())
                {
                    string textField = (string)element.Attribute("TextField");
                    foreach (XElement subElement in element.Elements())
                    {
                        List<string> textStrings = subElement.DescendantNodesAndSelf().Select(x => (string)((XElement)x).Attribute("TextField")).ToList();
                        textStrings.Insert(0, textField);
                        Console.WriteLine(string.Join(" > ", textStrings));
                    }
                }
                Console.ReadLine();
            }
        }
     
    }
