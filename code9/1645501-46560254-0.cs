    [Serializable]
    [XmlRoot("camera")]
    public class CamerasConfigAttrib : IXmlSerializable
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }
