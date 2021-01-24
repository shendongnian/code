            System.Xml.Serialization.XmlSerializer Serializer = new System.Xml.Serialization.XmlSerializer(typeof(Base));
            Base Foo = new Base();
            string xmldata = "";
            using (var stringwriter = new System.IO.StringWriter())
            {
                using (System.Xml.XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter))
                {
                    Serializer.Serialize(xmlwriter, Foo);
                    xml = stringwriter.ToString(); // Your XML
                }
            }
