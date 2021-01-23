	[XmlRoot("root")]
	public class RecordInfo
	{
		[XmlElement("property1")]
		public List<string> Property1;
		[XmlElement("amount")]
		public AmountRawData AmountData;
	}
	public class AmountRawData
	{
		[XmlAnyElement]
		public List<XmlElement> Content;
		public IEnumerable<AmountInfo> Parse()
		{
			foreach (var element in this.Content)
			{
				yield return
					new AmountInfo()
					{
						Currency = element.LocalName,
						Type = element.GetAttribute("type"),
						Amount = element.InnerText,
					};
			}
		}
	}
	public class AmountInfo
	{
		public string Currency;
		public string Type;
		public string Amount;
	}
