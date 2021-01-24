    public class Host {
        public Host()
        {
            c = new ChildClass(this);
        }
        [XmlElement("NAME")]
        public ChildClass c { get; set; }
    }
    [Serializable()]
    public class ChildClass : IXmlSerializable {
        private object _parent { get; }
        public ChildClass(object parent)
        {
            _parent = parent;
        }
        public void IXmlSerializable.WriteXml(XmlWriter writer) {
            var props = _parent.GetType().GetProperties();
            var propElement = props.Where(p => p.PropertyType == GetType()).FirstOrDefault();
            var desiredElementName = propElement.CustomAttributes.FirstOrDefault(p => p.AttributeType == typeof(XmlElementAttribute))?.ConstructorArguments.FirstOrDefault()?.Value;
            var desiredElement = _parent;
            XmlSerializer = new XmlSerializer(desiredElement.GetType(), new XmlRootAttribute(desiredElementName));
            serializer.Serialize(writer, desiredElment);
        }
    }
