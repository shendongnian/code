    public class WorldObjects
    {
        [XmlAnyAttribute]
        public XmlAttribute [] Attributes
        {
            get
            {
                var attr = new XmlDocument().CreateAttribute(XmlConvert.EncodeLocalName(type));
                attr.Value = name;
                return new[] { attr };
            }
            set
            {
                var attr = (value == null ? null : value.SingleOrDefault());
                if (attr == null)
                    name = type = string.Empty;
                else
                {
                    type = XmlConvert.DecodeName(attr.Name);
                    name = attr.Value;
                }
            }
        }
		
        [XmlIgnore]
        public string name;
        [XmlIgnore]
        public string type;
        // XmlSerializer required parameterless constructor
        public WorldObjects() : this(string.Empty, string.Empty) { }
        public WorldObjects(string _type, string _name)
        {
            type = _type;
            name = _name;
        }
    }
