     XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.IgnoreWhitespace = true;
            XmlReader reader = XmlReader.Create("XMLFile1.xml", settings);
            {
              
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element )
                    {
                        XmlNode node = doc.ReadNode(reader);
                        string json2 = JsonConvert.SerializeXmlNode(node);
                        Console.WriteLine(json2.Trim());
                    }
                }
            }
