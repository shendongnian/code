    [System.Serializable]
    [System.Xml.Serialization.XmlRoot(ElementName = "hard_disk")]
    public class HardDisk
    {
        [System.Xml.Serialization.XmlElement]
        public string model { get; set; }
        [System.Xml.Serialization.XmlElement]
        public int size { get; set; }
        public HardDisk() { }
    }
    [System.Serializable]
    [System.Xml.Serialization.XmlRoot(ElementName = "HardwareInfo")]
    public class Hardware
    {
        [System.Xml.Serialization.XmlElement]
        public string cpu_name { get; set; }
        [System.Xml.Serialization.XmlElement]
        public int ram_size { get; set; }
        [System.Xml.Serialization.XmlElement(ElementName = "hard_disk")]
        public List<HardDisk> hd { get; set; }
        public Hardware()
        {
            hd = new List<HardDisk>();
        }
    }
