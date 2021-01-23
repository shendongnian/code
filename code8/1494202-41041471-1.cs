    void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DataCollection));
    
        using (FileStream fileStream = new FileStream(@"file.xml", FileMode.Open)) {
            DataCollection result = (DataCollection)serializer.Deserialize(fileStream);
            result.Index();
            result.Ways[0].References[0].Node.Lon.Dump();
            // -> 5,9303625
        }
    }
    
    
    // --------------------------------------------------------------------------
    [XmlRoot("osm")]
    public class DataCollection {
        [XmlElement("n")]
        public List<Node> Nodes = new List<Node>();
    
        [XmlElement("w")]
        public List<Way> Ways = new List<Way>();
        
        public void Index() {
            var NodeById = this.Nodes.ToDictionary(n => n.ID, n => n);
            foreach (var way in this.Ways) {
                foreach (var nd in way.References) {
                    nd.Node = NodeById[nd.ReferenceID];
                }
            }
        }
    }
    
    // --------------------------------------------------------------------------
    [Serializable()]
    public class Node {
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }
    
        [XmlAttribute("w", DataType = "double")]
        public double Lat { get; set; }
    
        [XmlAttribute("l", DataType = "double")]
        public double Lon { get; set; }
    }
    
    // --------------------------------------------------------------------------
    [Serializable()]
    public class Way {
       [XmlAttribute("id", DataType = "long")]
       public long ID { get; set; }
    
       [XmlElement("nd")]
       public List<NodeReference> References = new List<NodeReference>();
    }
    	
    // --------------------------------------------------------------------------
    [Serializable()]
    public class NodeReference {
        [XmlAttribute("rf", DataType = "long")]
        public long ReferenceID { get; set; }
    
        [XmlIgnore]
        public Node Node { get; set; }
    }
