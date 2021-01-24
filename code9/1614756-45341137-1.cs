            var settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                while (reader.Read())
                {
                    if (reader.Name.Equals("xml"))
                    {
                    }
                }
            }
