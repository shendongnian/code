	// Include all possible types of Enum that might be serialized
    [XmlInclude(typeof(Enummies.BigMethods))]
    [XmlInclude(typeof(Enummies.SmallMethods))]
    public class TESTCLASS
    {
        private Enum _MethodType;
		// Surrogate object property for MethodObject required by XmlSerializer
        [XmlElement(Order = 1, ElementName = "MethodType")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public object MethodTypeObject
        {
            get { return MethodType; }
            set { MethodType = (Enum)value; }
        }
		// Ignore the Enum member that cannot be serialized directly
        [XmlIgnore]
        public Enum MethodType
        {
            get { return _MethodType; }
            set { _MethodType = value; }
        }
        public TESTCLASS() { }
        public TESTCLASS(Enummies.BigMethods bigM)
        {
            MethodType = bigM;
        }
        public TESTCLASS(Enummies.SmallMethods smallM)
        {
            MethodType = smallM;
        }
    }
