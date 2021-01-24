    using System;
    using System.Xml;
    using System.Xml.Serialization;
    
    [XmlRoot("NameOfMyRoot")]
    public class Inner
    {
        public Inner() { }
        [XmlElement(Namespace = "myNamespace")]
        public string SomeString { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            using (XmlWriter writer = XmlWriter.Create(Console.Out))
            {
                writer.WriteStartDocument(false);
                writer.WriteStartElement("Root");
    
                var ser = new XmlSerializer(typeof(Inner));
                var obj = new Inner { SomeString = "abc" };
    
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                ns.Add("ns", "myNamespace");
                ser.Serialize(writer, obj, ns);
    
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
