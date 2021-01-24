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
            const string ADD_FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XDocument addDoc = XDocument.Load(ADD_FILENAME);
                XElement docRoot = doc.Root;
                XElement addRoot = addDoc.Root;
                foreach (XElement child in addRoot.Elements())
                {
                    string elementName = child.Name.LocalName;
                    XElement docElement = docRoot.Element(elementName);
                    docElement.Add(child.FirstNode);
                }
            }
        }
    }
