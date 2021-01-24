    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XElement doc = XElement.Load(FILENAME);
                List<XElement> nodes = doc.Descendants().Where(element => element.Name.LocalName.Equals("oldName")).ToList();
                for(int index = nodes.Count() - 1; index >= 0; index--)
                {
                    XElement node = nodes[index];
                    node.ReplaceWith(new XElement("newName", node.Descendants()));
                }
            }
        }
    }
