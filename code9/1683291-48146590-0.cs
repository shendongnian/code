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
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                List<XElement> testObject = root.Descendants(ns + "testObject").Where(x => ((string)x.Attribute("class") == "BTSSCL") || ((string)x.Attribute("class") == "LNCEL")).ToList();
            }
        }
    }
