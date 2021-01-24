	[XmlRoot("config")]
	public class SomeConfiguration
	{
		[XmlElement("bugs")]
		public BugList Bugs { get; set; }
		[XmlElement("trees")]
		public TreeList Trees { get; set; }
	}
	
	[XmlRoot("bugs")]
	public class BugList 
	{
		[XmlElement("bug")]
		public List<string> Items = new List<string>();
	}
	
	[XmlRoot("trees")]
	public class TreeList
	{
		[XmlElement("tree")]
		public List<string> Items = new List<string>();
	}	
