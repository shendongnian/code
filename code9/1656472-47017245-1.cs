                XmlSerializer xmlSerializer = new XmlSerializer(typeof(*NameOfYourClass*));
                using (StringWriter writer = new StringWriter())
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
                    {
                        xmlWriter.Formatting = Formatting.Indented;
                        xmlWriter.Indentation = 4;
                        xmlSerializer.Serialize(xmlWriter, *InstanceOfYourClass*);
                        return writer.ToString());
                    }
                }
