    [XmlType("i")]
    public class DtoI
    {
        [XmlAttribute("Object_ID")]
        public int Id;
        [XmlAttribute("attribute1")]
        public String Attribute1;
        [XmlAttribute("attribute2")]
        public String Attribute2;
        [XmlAttribute("attributex")]
        public Int32 AttributeX;
    }
    public static T[] DeserializeArray<T>(String xml)
    {
        using (var reader = new StringReader(xml))
        {
            var serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute("root"));
            return (T[])serializer.Deserialize(reader);
        }
    }
