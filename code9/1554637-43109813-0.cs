          [Serializable]
            [XmlRoot(ElementName = "HardwareInfo")]
            public class Hardware
            {
                [XmlElement]
                public string cpu_name { get; set; }
                [XmlElement]
                public int ram_size { get; set; }
                [XmlElement("hard_disk")]
                public List<HardDisk> hd { get; set; }                   
            }
            [Serializable]
            [XmlRoot(ElementName = "hard_disk")]
            public class HardDisk
            {
                [XmlElement]
                public string model { get; set; }
                [XmlElement]
                public string size { get; set; }
            }
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlString = @"<HardwareInfo>
                                      <cpu_name> ABC Pentium xyz</cpu_name>
                                      <ram_size> 123 </ram_size>
                                      <hard_disk>
                                        <model>Toshiba XYZ</model>
                                        <size> 123 GB </size>
                                      </hard_disk>
                                      <hard_disk>
                                        <model>Logitech XYZ</model>
                                        <size> 99 GB </size>
                                      </hard_disk>
                                    </HardwareInfo>";
                var result = DeSerialization<Hardware>(xmlString);
            }
            static T DeSerialization<T>(string xmlStrig) where T : class
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));                        
                using (StringReader sReader = new StringReader(xmlStrig))
                {
                    return (T)xmlSerializer.Deserialize(sReader);
                }
            }
        }          
    }
