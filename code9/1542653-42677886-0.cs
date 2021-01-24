    public class MyClass : IXmlSerializable
    {
        public int A { get; set; }
        public int B { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            /*
             * https://msdn.microsoft.com/en-us/library/system.xml.serialization.ixmlserializable.readxml.aspx
             * 
             * When this method is called, the reader is positioned at the start of the element that wraps the information for your type. 
             * That is, just before the start tag that indicates the beginning of a serialized object. When this method returns, 
             * it must have read the entire element from beginning to end, including all of its contents. Unlike the WriteXml method, 
             * the framework does not handle the wrapper element automatically. Your implementation must do so. Failing to observe these 
             * positioning rules may cause code to generate unexpected runtime exceptions or corrupt data.
             */
            var isEmptyElement = reader.IsEmptyElement;
            this.A = XmlConvert.ToInt32(reader.GetAttribute("A"));
            this.B = XmlConvert.ToInt32(reader.GetAttribute("B"));
            reader.ReadStartElement();
            if (!isEmptyElement)
            {
                reader.ReadEndElement();
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("A", XmlConvert.ToString(this.A));
            writer.WriteAttributeString("B", XmlConvert.ToString(this.B));
        }
    }
