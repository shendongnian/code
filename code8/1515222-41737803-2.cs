    public class WorldObjects
    {
        [XmlAnyAttribute]
        public XmlAttribute [] Attributes
        {
            get
            {
                var attr = new XmlDocument().CreateAttribute(XmlConvert.EncodeLocalName(name));
                attr.Value = type;
                return new[] { attr };
            }
            set
            {
                var attr = (value == null ? null : value.SingleOrDefault());
                if (attr == null)
                    name = type = string.Empty;
                else
                {
                    name = XmlConvert.DecodeName(attr.Name);
                    type = attr.Value;
                }
            }
        }
        [XmlIgnore]
        public string name;
        [XmlIgnore]
        public string type;
        // XmlSerializer required parameterless constructor
        WorldObjects() : this(string.Empty, string.Empty) { }
        public WorldObjects(string _type, string _name)
        {
            type = _type;
            name = _name;
        }
    }
