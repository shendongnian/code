    private static string XMLSerializer(object obj)
        {
            string xml = "";
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            };
            using (var sww = new Utf8StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww, xmlWriterSettings))
                {
                        XmlSerializer serializer = new XmlSerializer(obj.GetType());
                        serializer.Serialize(writer, obj, ns);
                    xml = sww.ToString();
                }
            }
            return xml;
        }
        private sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
