     XmlSerializer serializer = new XmlSerializer(typeof(ObjKompParam),"");
            XElement xe;
            using (var stream = new MemoryStream()) //write into stream
            {
                serializer.Serialize(stream, param, ns); //writer, object
                stream.Position = 0;
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    xe = XElement.Load(reader);
                }
            }
            var child = xe.Descendants();
            body.Descendants(prod + "ADSobjotsing").First().Add(child);
            return body;
