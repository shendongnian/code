    [Serializable]
    [XmlRoot("Data")]
    public class Data
    {
    	[XmlArray("Blocks")]
    	[XmlArrayItem("Block")]
    	public List<Block> Blocks { get; set; }
    }
    
    [Serializable]
    public class Block
    {
    	public string Name { get; set; }
    	public int ID { get; set; }
    }
