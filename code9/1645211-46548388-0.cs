           const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(INPUT_FILENAME );
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME, settings);
                writer.WriteStartElement("root");
              
                while (reader.Read())
                {
                    writer.WriteRaw(reader.ReadOuterXml());
                }
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
