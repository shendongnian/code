    public class SomeData : IXmlSerializable
    {
        public int RangeX { get; set; }
    
        public int RangeY { get; set; }
    
        public int RangeY { get; set; }
    
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteStartElement("SomeData");
            if (RangeX != 0)
            {
                writer.WriteElementString("rangeX", RangeX.ToTring());
            }
            if (RangeY != 0)
            {
                writer.WriteElementString("rangeY", RangeY.ToTring());
            }
            if (RangeZ != 0)
            {
                writer.WriteElementString("rangeZ", RangeZ.ToTring());
            }
            writer.WriteEndElement();
        }
    
        public void ReadXml (XmlReader reader)
        {
            //Implement if needed
            throw new NotImplementedException();
        }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
