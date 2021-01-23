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
                foreach (XElement descendant in doc.Descendants())
                {
                    for (int i = descendant.Attributes().Count() - 1; i > 0; i--)
                    {
                        XAttribute attr = descendant.Attributes().Skip(i).FirstOrDefault();
                        switch (attr.Name.LocalName)
                        {
                            case "type":
                                descendant.Add(new XAttribute("name", attr.Value));
                                attr.Remove();
                                break;
                            case "model":
                                descendant.Add(new XAttribute("model-no", attr.Value));
                                attr.Remove();
                                break;
                        }
                    }
                }
            }
        }
    }
