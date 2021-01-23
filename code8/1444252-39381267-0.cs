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
                Dictionary<string, string> settingsDict = new Dictionary<string, string>();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader reader = XmlReader.Create(FILENAME, settings);
                while (!reader.EOF)
                {
                    if (reader.Name != "add")
                    {
                        reader.ReadToFollowing("add");
                    }
                    if (!reader.EOF)
                    {
                        XElement add = (XElement)XElement.ReadFrom(reader);
                        settingsDict.Add((string)add.Attribute("key"), (string)add.Attribute("value"));
                    }
                }
            }
        }
    }
