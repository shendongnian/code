    public abstract class RPPItemBase
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("kind")]
        public string Kind { get; set; }
        bool ShouldSerializeKind() { return !string.IsNullOrEmpty(Kind); }
    }
    [XmlRoot("object")]
    public class RPPProjectDTO : RPPItemBase
    {
        public RPPProjectDTO() { this.Kind = "project"; }
        [XmlAttribute("states")]
        public string States { get; set; }
        [XmlElement("fields")]
        public RPPProjectFieldsDTO Fields { get; set; }
    }
    [XmlRoot("fields")]
    public class RPPProjectFieldsDTO
    {
        [XmlElement("field")]
        public RPPProjectFieldDTO[] Fields { get; set; }
    }
    public class RPPProjectFieldDTO : RPPItemBase
    {
        [XmlAttribute("data")]
        public string Data { get; set; }
        [XmlAttribute("unit")]
        public string Unit { get; set; }
        public bool ShouldSerializeUnit() { return !string.IsNullOrEmpty(Unit); }
    }
