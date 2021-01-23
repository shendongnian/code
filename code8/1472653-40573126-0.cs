    public class ColorFormat : IXmlSerializable
    {
        ...
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            Name = reader.GetAttribute(nameof(Name));
            ColorBase = CommonUtil.ParseStringToEnum<NumberBase>(reader.GetAttribute(nameof(ColorBase)));
            Format = reader.ReadInnerXml();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Name), Name);
            writer.WriteAttributeString(nameof(ColorBase), ColorBase.ToString());
            writer.WriteRaw(Format);
        }
    }
