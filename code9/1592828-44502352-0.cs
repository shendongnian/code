    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication62
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "invalidXMLWithoutDeclaration")
                    {
                        reader.ReadToFollowing("invalidXMLWithoutDeclaration");
                    }
                    if (!reader.EOF)
                    {
                        XElement invalidXMLWithoutDeclaration = (XElement)XElement.ReadFrom(reader);
                    }
                }
               
            }
        }
    }
