    public class Results : IXmlSerializable
    {
        public int Count { get; set; }
        public List<Result> ResultItems { get; set; }
        
        public Results()
        {
            ResultItems = new List<Result>();
        }
        public XmlSchema GetSchema()
        {
            return (null);
        }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Results");
            
            if(reader.Name == "Count")
            {
                Count = reader.ReadElementContentAsInt();
            }
            for (int i = Count; i > 0; i--)
            {
                var result = new Result();
                reader.ReadStartElement("Result" + i);
                result.Property1 = reader.ReadElementContentAsInt();
                result.Property2 = reader.ReadElementContentAsString();
                ...
                ...
                result.PropertyN = reader.ReadElementContentAsString();
                ResultItems.Add(result);
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            //I don't ever need to write this to XML, 
            //so I'm not going to implement this
            throw new NotImplementedException();
        }
    }
