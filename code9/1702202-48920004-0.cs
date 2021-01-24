	public class CommonMasterDataResponse
	{
		public CommonMasterDataResponse()
		{
		}
		public bool ShouldSerializeDto1()
		{
			return Dto1.Any();
		}
		[XmlElement(IsNullable = true)]
		public List<string> Dto1 { get; set; }
	}
