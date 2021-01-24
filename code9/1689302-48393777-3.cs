        public T DeserializeXml<T>(string str)
        {
            var se = new XmlSerializer(typeof(T));
            object obj;
            using (var reader = new StringReader(str))
            {
                obj = se.Deserialize(reader);
            }
            return (T) obj;
        }
        public static string XmlSerializeToString(object obj)
        {
            var se = new XmlSerializer(obj.GetType());
            var sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                se.Serialize(writer, obj);
            }
            return sb.ToString();
        }
        [XmlRoot(ElementName = "person")]
        public class Person
        {
            [XmlElement(ElementName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "url")]
            public string Url { get; set; }
            public override string ToString()
            {
                return XmlSerializeToString(this);
            }
        }
        [XmlRoot(ElementName = "userimage")]
        public class Userimage
        {
            [XmlElement(ElementName = "person")]
            public List<Person> Person { get; set; }
            public override string ToString()
            {
                return XmlSerializeToString(this);
            }
        }
