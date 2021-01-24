    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication4
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static List<XElement> nodes;
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                nodes = doc.Root.Elements().ToList();
                XElement child = new XElement("root");
                RecursvieAdd(child, 0);
                XDocument doc2 = new XDocument(child);
            }
            static void RecursvieAdd(XElement child, int index)
            {
                XElement newChild = new XElement(nodes[index]);
                child.Add(newChild);
     
                if (index < nodes.Count - 1)
                {
                    RecursvieAdd(newChild, index + 1);
                }
            }
        }
     
    }
