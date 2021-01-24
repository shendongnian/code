            System.Xml.Serialization.XmlSerializer Serializer = new System.Xml.Serialization.XmlSerializer(typeof(Base));
            Base Foo = new Base();
            string xmldata = "";
            using (var writer = new System.IO.StringWriter())
            {
                using (System.Xml.XmlWriter somewriter = System.Xml.XmlWriter.Create(writer))
                {
                    Serializer.Serialize(somewriter, Foo);
                    xml = somewriter.ToString(); // Your XML
                }
            }
