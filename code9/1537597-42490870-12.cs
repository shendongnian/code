	[XmlRoot(ElementName="_Example")]
	public class _Example {
		[XmlElement(ElementName="_SenseNot")]
		public string _SenseNot { get; set; }
		[XmlElement(ElementName="_GrammaticNot")]
		public string _GrammaticNot { get; set; }
		[XmlElement(ElementName="_Desc")]
		public string _Desc { get; set; }
	}
	[XmlRoot(ElementName="_perSubExample")]
	public class _perSubExample {
		[XmlElement(ElementName="_UpperTitle")]
		public string _UpperTitle { get; set; }
		[XmlElement(ElementName="_FormGroup")]
		public string _FormGroup { get; set; }
		[XmlElement(ElementName="_SenseNot")]
		public string _SenseNot { get; set; }
		[XmlElement(ElementName="_GrammaticNot")]
		public string _GrammaticNot { get; set; }
		[XmlElement(ElementName="_Desc")]
		public string _Desc { get; set; }
		[XmlElement(ElementName="_Example")]
		public List<_Example> _Example { get; set; }
		[XmlElement(ElementName="_Synonyms")]
		public string _Synonyms { get; set; }
	}
	[XmlRoot(ElementName="_perMainExample")]
	public class _perMainExample {
		[XmlElement(ElementName="_perSubExample")]
		public List<_perSubExample> _perSubExample { get; set; }
	}
	[XmlRoot(ElementName="_perGroup")]
	public class _perGroup {
		[XmlElement(ElementName="_GroupDesc")]
		public string _GroupDesc { get; set; }
		[XmlElement(ElementName="_GroupSense")]
		public string _GroupSense { get; set; }
		[XmlElement(ElementName="_GroupGrammer")]
		public string _GroupGrammer { get; set; }
		[XmlElement(ElementName="_perMainExample")]
		public List<_perMainExample> _perMainExample { get; set; }
	}
	[XmlRoot(ElementName="OxFordDefinition")]
	public class OxFordDefinition {
		[XmlElement(ElementName="sourceURL")]
		public string SourceURL { get; set; }
		[XmlElement(ElementName="originDesc")]
		public string OriginDesc { get; set; }
		[XmlElement(ElementName="_perGroup")]
		public List<_perGroup> _perGroup { get; set; }
	}
