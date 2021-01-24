    public class Book
    {
    	public string Author { get; set; }
    	[System.Xml.Serialization.XmlElement(IsNullable = true)]
    	public string ISBN { get; set; }
    }
