            System.Xml.Serialization.XmlSerializer Serializer = new System.Xml.Serialization.XmlSerializer(typeof(Employee));
            Employee Foo = new Employee();
            string xmldata = "";
            using (var writer = new System.IO.StringWriter())
            {
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(writer))
                {
                    Foo.Serialize(writer, Foo);
                    xml = writer.ToString(); // Your XML
                }
            }
