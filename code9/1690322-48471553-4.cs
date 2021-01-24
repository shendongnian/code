    public class BaseClass
    {
    }
    public class DerivedClass : BaseClass, IXmlSerializable
    {
        #region IXmlSerializable Members
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader) { throw new NotImplementedException(); }
        public void WriteXml(XmlWriter writer) { }
        #endregion
    }
