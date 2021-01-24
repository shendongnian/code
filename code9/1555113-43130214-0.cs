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
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "Parent")
                    {
                        reader.ReadToFollowing("Parent");
                    }
                    if (!reader.EOF)
                    {
                        XElement parent = (XElement)XDocument.ReadFrom(reader);
                        foreach (XElement child in parent.Elements())
                        {
                            XElement grandchild = child.Elements().FirstOrDefault();
                            Console.WriteLine("tag : '{0}', value : '{1}'", grandchild.Name.LocalName, (string)grandchild);
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
