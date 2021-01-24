    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication74
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "node")
                    {
                        reader.ReadToFollowing("node");
                    }
                    if (!reader.EOF)
                    {
                        XElement node = (XElement)XElement.ReadFrom(reader);
                    }
                }
            }
        }
    }
