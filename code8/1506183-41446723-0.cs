    public class SomeObject
    {
        [XmlIgnore]
        public SensorUID SensorUID { get; set; }
        [XmlIgnore]
        public FileName FileName { get; set; }
        [XmlAttribute("SensorUID")]
        public string SensorUIDAsString
        {
            get { return SensorUID == null ? null : SensorUID.ID; }
            set { SensorUID = new SensorUID(value); }
        }
        [XmlAttribute("FileName")]
        public string FileNameAsString
        {
            get { return FileName == null ? null : FileName.ID; }
            set { FileName = new FileName(value); }
        }
    }
