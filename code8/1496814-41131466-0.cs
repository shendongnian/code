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
            const string INPUT_FILENAME = @"c:\temp\test1.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(INPUT_FILENAME);
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME);
                writer.WriteStartElement("resultset");
                while (!reader.EOF)
                {
                    if (reader.Name != "result")
                    {
                        reader.ReadToFollowing("result");
                    }
                    if (!reader.EOF)
                    {
                        XElement result = (XElement)XElement.ReadFrom(reader);
                        result.Element("new_categoria").Name = "org_category";
                        result.Element("new_name").Name = "org_name";
                        result.Element("new_tipodecampanaid").Name = "org_campaignid";
                        writer.WriteRaw(result.ToString());
                    }
                }
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
