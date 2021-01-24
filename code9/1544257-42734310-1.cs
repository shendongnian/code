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
                reader.ReadStartElement(); //read root
                XElement.ReadFrom(reader);// read \n
                XElement record = null;
                string recordName = "";
                Boolean first = true;
                while (!reader.EOF)
                {
                    if (first)
                    {
                        record = (XElement)XElement.ReadFrom(reader);
                        first = false;
                        recordName = record.Name.LocalName;
                    }
                    else
                    {
                        if (reader.Name != recordName)
                        {
                            reader.ReadToFollowing(recordName);
                        }
                        if (!reader.EOF)
                        {
                            record = (XElement)XElement.ReadFrom(reader);
                        }
                    }
                }
            }
        }
    }
