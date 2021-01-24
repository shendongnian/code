	[XmlArray("Elements")]
	[XmlArrayItem("element")]
	public List<string> Elements { get; set; }
	[XmlIgnore]
	public List<string> CandidateElementsSurrogate { get { return Elements.ToList(); } set { Elements = value; } }
