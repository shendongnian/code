    [System.Xml.Serialization.XmlRoot(ElementName = "hard_disk")]
    public class HardDisk
    {
        public string model { get; set; }
        public int size { get; set; }
        public HardDisk() { }
    }
    [System.Xml.Serialization.XmlRoot(ElementName = "HardwareInfo")]
    public class Hardware
    {
        public string cpu_name { get; set; }
        public int ram_size { get; set; }
        [System.Xml.Serialization.XmlElement(ElementName = "hard_disk")]
        public List<HardDisk> hd { get; set; }
        public Hardware()
        {
            hd = new List<HardDisk>();
        }
    }
