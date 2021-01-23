    /// <summary>
    /// When serialized, sampleObj is 'Parm' element
    /// </summary>
    [XmlRoot("Parm")]
    public class sampleObj
    {
        /// <summary>
        /// Name is an attribute of sampleObj/Parm
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }
        /// <summary>
        /// Value is an element of sampleObj/Parm
        /// </summary>
        [XmlElement("Value")]
        public string Value { get; set; }
        /// <summary>
        /// sampleObj has sampleObj list as elements
        /// </summary>
        [XmlElement("Parm")]
        public List<sampleObj> sampleObjs { get; set; }
    }
