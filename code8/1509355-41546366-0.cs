    public class MyXmlSerializableClass : IXmlSerializable
    {
        private ESomeEnum emode = ESomeEnum.modefirst;
        public string Mode
        {
            set { emode = ESomeEnum.Parse(value); }
        }
        public int ReadWriteProperty { get; set; }
        public int SemiReadOnlyProperty { get; private set; }
        private int backingFieldOfRealReadOnlyProperty;
        public int RealReadOnlyProperty
        {
            get { return backingFieldOfRealReadOnlyProperty; }
        }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            if (reader.Settings != null && !reader.Settings.IgnoreWhitespace)
            {
                reader = XmlReader.Create(reader, new XmlReaderSettings { IgnoreWhitespace = true });
                reader.Read();
            }
            reader.ReadStartElement();
            Mode = reader.ReadElementContentAsString("Mode", String.Empty);
            ReadWriteProperty = reader.ReadElementContentAsInt("ReadWriteProperty", String.Empty);
            SemiReadOnlyProperty = reader.ReadElementContentAsInt("ReadOnlyAutoProperty", String.Empty);
            backingFieldOfRealReadOnlyProperty = reader.ReadElementContentAsInt("ReadOnlyProperty", String.Empty);
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Mode", emode.ToString());
            writer.WriteElementString("ReadWriteProperty", ReadWriteProperty.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("ReadOnlyAutoProperty", SemiReadOnlyProperty.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("ReadOnlyProperty", RealReadOnlyProperty.ToString(CultureInfo.InvariantCulture));
        }
        #endregion
        internal MyXmlSerializableClass()
        {/*needed for deserialization*/
        }
    }
