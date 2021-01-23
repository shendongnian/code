    [Serializable]
    class XmlModel : IXmlSerializable {
        public XElement _foo = new XElement(
            "Foo", new XElement( "Bar", "Baz" ) );
        public XmlModel( XElement Foo ) {
            _foo = Foo;
        }
        public XmlSchema GetSchema( ) {
            return null;
        }
        public void ReadXml( XmlReader reader ) {
            this._foo = XElement.Load( reader );
        }
        public void WriteXml( XmlWriter writer ) {
            _foo.WriteTo( writer );
        }
    }
