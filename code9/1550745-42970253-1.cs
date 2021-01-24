	[XmlIgnore]
	public List<string> Elements { get; set; }
	[XmlArray("Elements")]
	[XmlArrayItem("element")]
	public List<string> CandidateElementsSurrogate { get { return Elements; } set { Elements = value; } }
