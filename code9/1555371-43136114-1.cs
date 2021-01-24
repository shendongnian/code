            var serializer = new JavaScriptSerializer();
            var json1 = "{count:[{first:1,second:2,third:3},{first:11,second:22,third:33},{first:111,second:222,third:333}]}";
            var obj = serializer.Deserialize<jClass>(json1);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(jClass));
            string xmlString;
            using (System.IO.StringWriter sww = new System.IO.StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, obj);
                    xmlString = sww.ToString();
                }
            }
