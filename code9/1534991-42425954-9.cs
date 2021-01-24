            public class MigrationAndDevicesBin
            {
                [XmlAttribute("name")]
                public string name;
                [XmlAttribute("exec")]
                public string exec;
                // Fixed - should be [XmlElement]
                [XmlElement("Device")]
                public List<Device> _Device;
