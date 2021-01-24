    public class ObjSer
    {
        [XmlElement("Name")]
        public XElement Name
        {
            get; set;
        }
    }
    
    static void Main(string[] args)
    {
        //Code to serialize
        var obj = new ObjSer();
        obj.Name = XDocument.Parse("<tag1>Value</tag1>").Document.FirstNode as XElement;
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
        serializer.Serialize(Console.Out, obj);
    }
