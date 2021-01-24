    public class ModelXML
    {
        public class Column
        {
            [XmlAttribute("name")]
            public string Name { set; get; }
            [XmlText]
            public string Value { set; get; }
        }
        [XmlElement("column")]
        public List<Column> Columns { get; set; }
    }
    IEnumerable<T> Deserialize<T>(IEnumerable<XElement> elements)
    {
        foreach (var element in elements)
        {
            using (var reader = XDocument.Parse(element.ToString()).CreateReader())
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T), new XmlRootAttribute("row"));
                yield return (T)deserializer.Deserialize(reader);
            }
        }
    }
                
    var document = XDocument.Parse(xml_str);
    var collection = Deserialize<ModelXML>(document.XPathSelectElements("response/result/rows/row"));
