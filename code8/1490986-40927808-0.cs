    public class SerialNumbers : List<SerialNumber>, IXmlSerializable
    {
    	public XmlSchema GetSchema()
    	{
    		return null;
    	}
    
    	public void ReadXml(XmlReader reader)
    	{
    		Clear();
    		reader.ReadStartElement();
    		while (reader.NodeType != XmlNodeType.EndElement)
    		{
    			var serialNumber = new SerialNumber
    			{
    				Type = reader.ReadElementContentAsString("Type", ""),
    				Number = reader.ReadElementContentAsString("Number", "")
    			};
    			Add(serialNumber);
    		}
    		reader.ReadEndElement();
    	}
    
    	public void WriteXml(XmlWriter writer)
    	{
    		foreach (var serialNumber in this)
    		{
    			writer.WriteElementString("Type", serialNumber.Type);
    			writer.WriteElementString("Number", serialNumber.Number);
    		}
    	}
    }
    
    public class SerialNumber
    {
    	public string Type { get; set; }
    	public string Number { get; set; }
    }
