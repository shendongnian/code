    public class CoreFinancial {
		public string FieldTypeEnum { get; set; }
		public string IsGpBasedRiskOrder { get; set; }
		public string IsMultiSelect { get; set; }
		public string LableText { get; set; }
		public string MappingOptions { get; set; }
		public string MappingType { get; set; }
		public string SchemaField { get; set; }
		public string Value { get; set; }
		public string ErrCount { get; set; }
		public string ValueError { get; set; }
		public MappingOptionsColumns MappingOptionsColumns { get; set; }
	}
	public class MappingOptionsColumns {
		[XmlElement(ElementName="value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
	}
	public class Financial {
		public List<CoreFinancial> CoreFinancial { get; set; }
	}
