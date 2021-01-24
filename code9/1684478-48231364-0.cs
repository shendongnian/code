    returns Deserialize(string xmlString)
    {
         returns obj = null;
         using (TextReader textReader = new StringReader(xmlString))
                {
                    using (XmlTextReader reader = new XmlTextReader(xmlString))
                    {
                        reader.Namespaces = false;
                        XmlSerializer serializer = new XmlSerializer(typeof(returns));
                        obj = (returns)serializer.Deserialize(reader);
                    }
                }
            return obj;
    }
