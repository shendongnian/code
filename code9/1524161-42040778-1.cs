	[XmlRoot("ArrayOfSounds")]
	public class CSoundsRoot
	{
		public CSoundsRoot() { this.Sounds = new List<CSound>(); }
		
		[XmlElement("CSound")]
		public List<CSound> Sounds { get; set; }
	}
