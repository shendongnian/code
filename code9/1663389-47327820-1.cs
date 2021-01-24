            CoolElement cool = null;
            string path = @"yourxmlfilename.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(CoolElement));
            using (var reader = XmlReader.Create(path))
            {
                cool = (CoolElement)serializer.Deserialize(reader);
                Console.WriteLine("master value: " + cool.master.Value);
                Console.WriteLine("attribute visible value: " + cool.master.visible);
            }
