    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME, Encoding.Unicode);
                reader.ReadLine(); //skip xml identification due to unicode not being recognized.
                XDocument doc = XDocument.Load(reader);
                XElement root = doc.Root;
                string xmlHeader = string.Format("<?xml version=\"1.0\" encoding=\"utf-16\" standalone=\"yes\"?><{0}></{0}>", (string)root.Attributes().FirstOrDefault());
                XDocument newDoc = XDocument.Parse(xmlHeader);
                XElement newRoot = newDoc.Root;
                RecursiveParse(root, newRoot);
            }
            static void RecursiveParse(XElement parent, XElement newParent)
            {
                List<XElement> children = parent.Elements().ToList();
                if (children != null)
                {
                    foreach (XElement child in children)
                    {
                         
                        if (child.Name.LocalName != "null")
                        {
                            string innerTag = (string)(XElement)child.FirstNode;
                            XElement newChild = new XElement((string)child.Attributes().FirstOrDefault());
                            newParent.Add(newChild);
                            
                            if (innerTag != "")
                            {
                                newParent.Add(innerTag);
                            }
                            else
                            {
                                RecursiveParse(child, newChild);
                            }
                        }
                    }
                }
            }
        }
    }
