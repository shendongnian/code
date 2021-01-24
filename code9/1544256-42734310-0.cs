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
                    if (reader.Name != "record")
                    {
                        reader.ReadToFollowing("record");
                    }
                    if (!reader.EOF)
                    {
                        XElement record = (XElement)XElement.ReadFrom(reader);
                    }
                }
            }
        }
    }
