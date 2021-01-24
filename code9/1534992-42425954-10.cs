            public class SerialFlashHexImage
            {
                [XmlAttribute("name")]
                public string name;
                [XmlAttribute("exec")]
                public string exec;
                // Fixed - the type File was not even used!
                [XmlElement("File")]
                public List<File> Files { get; set; }
                public SerialFlashHexImage()
                {
                    this.Files = new List<File>();
                    name = "";
                    exec = "";
                }
