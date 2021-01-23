    using System;
    using System.Text;
    using System.Xml;
    
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriter xmlWriter = XmlWriter.Create("foo.xml");
    
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("root");
    
            xmlWriter.WriteStartElement("someElement");
            xmlWriter.WriteAttributeString("anAttribute", "42");
            xmlWriter.WriteString("Node Content");
            xmlWriter.WriteEndElement();
    
            xmlWriter.WriteStartElement("someElement");
            xmlWriter.WriteAttributeString("anAttribute", "39");
            xmlWriter.WriteString("Node Content");
    
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
    }
