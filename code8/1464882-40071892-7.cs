	[DataContract(Namespace = "")]
	public class url
	{
		[DataMember]
		public string loc { get; set; }
		[DataMember]
		public DateTime lastmod { get; set; }
		[DataMember]
		public double priority { get; set; }
	}
