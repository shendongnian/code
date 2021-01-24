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
                XmlReader reader = XmlReader.Create(FILENAME, settings);
                List<string> meshFiles = new List<string>();
                while (!reader.EOF)
                {
                    if (reader.Name != "property")
                    {
                        reader.ReadToFollowing("property");
                    }
                    if (!reader.EOF)
                    {
                        XElement property = (XElement)XElement.ReadFrom(reader);
                        if ((string)property.Attribute("name") == "Meshfile")
                        {
                            meshFiles.Add((string)property.Attribute("value"));
                        }
                    }
                }
            }
        }
    }
