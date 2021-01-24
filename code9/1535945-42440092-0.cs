            // Generic DeSerialization metod.
            public T DeSerialization<T>(string xmlStrig)  where T : class
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (StringReader sReader = new StringReader(xmlStrig))
                {
                    return (T)xmlSerializer.Deserialize(sReader);
                }
            }
            // Accepted class
            [Serializable]    
            public class AdditionalInfo
            {
                [XmlElement]
                public string Number { get; set; }
            }
            // DeSerialize to Object
            // if you have Xml-string you can send parameter XmlString directly
            string xmlString = System.IO.File.ReadAllText(@"..\\XMLFile1.xml");
            AdditionalInfo ast = DeSerialization<AdditionalInfo>(xmlString);
