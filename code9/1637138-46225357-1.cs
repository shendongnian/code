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
                XElement parent = new XElement("root");
                RecursvieAdd(parent, "");
                XDocument doc2 = new XDocument(parent);
            }
            static void RecursvieAdd(XElement parent, string parentId)
            {
                foreach(XElement child in nodes.Where(x => (string)x.Element("parent-id") == parentId))
                {
                   XElement newChild = new XElement(child);
                   parent.Add(newChild);
                   string id = (string)child.Element("node-id");
                   RecursvieAdd(newChild, id);
                }
            }
        }
    }
