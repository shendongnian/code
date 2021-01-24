    public string SerializeXml<T>(T config) 
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                string xml = "";
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = false;
    
                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww, settings))
                    {
                        xsSubmit.Serialize(writer, config);
                        xml = sww.ToString();
                    }
                }
    
                return xml;
            }
