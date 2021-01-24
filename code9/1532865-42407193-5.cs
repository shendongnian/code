    [XmlInclude(typeof(DerivedT))]
    public class BaseT
    {
        [XmlAttribute("type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] // Hide this useless property
        public string XmlSchemaType
        {
            get { return null; } // Always return null for XmlSerializer.Serialize to work
            set { }
        }
    }
