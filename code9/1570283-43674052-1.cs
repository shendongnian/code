    [XmlRoot(ElementName = "Door", DataType = "string")]
    public class UpdateDoorCommand : IXmlSerializable
    {
        // *snip*
    
        public void WriteXml(XmlWriter writer)
        {
            //writer.WriteStartElement("Door");
            writer.WriteAttributeString("Address", "D1");
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Notes", Notes);
            //writer.WriteEndElement();   
        }
    }
