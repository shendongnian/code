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
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader reader = XmlReader.Create(FILENAME,settings);
                while (!reader.EOF)
                {
                    if (reader.Name != "root")
                    {
                        reader.ReadToFollowing("root");
                    }
                    if (!reader.EOF)
                    {
                        XElement root = (XElement)XElement.ReadFrom(reader);
                    }
                }
            }
        }
    }
