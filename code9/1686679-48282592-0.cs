    public class ObjSer
    {
        [XmlElement("Name")]
        public XmlElement Name
        {
            get; set;
        }
    }
    var obj = new ObjSer();
    // <-- load xml
    var doc = new XmlDocument();
    doc.LoadXml("<tag1>Value</tag1>");
    obj.Name = doc.DocumentElement;
    // --> assign the element
    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
    serializer.Serialize(Console.Out, obj);
