	public async Task<ActionResult> Index(string language)
	{
		if (String.IsNullOrWhiteSpace(language) == false)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
		}
		else if (String.IsNullOrWhiteSpace(language))
		{
			string userIpAddress = this.Request.UserHostAddress;
			var client = new HttpClient
			{
				BaseAddress = new Uri("http://freegeoip.net/xml/")
			};
			var response = await client.GetAsync(userIpAddress);
			var content = await response.Content.ReadAsStringAsync();
			var result = (Response)new XmlSerializer(typeof(Response)).Deserialize(new StringReader(content));
			// do stuff
		}
		...
	}
	[XmlRoot(ElementName = "Response")]
	public class Response
	{
		[XmlElement(ElementName = "IP")]
		public string IP { get; set; }
		[XmlElement(ElementName = "CountryCode")]
		public string CountryCode { get; set; }
		[XmlElement(ElementName = "CountryName")]
		public string CountryName { get; set; }
		[XmlElement(ElementName = "RegionCode")]
		public string RegionCode { get; set; }
		[XmlElement(ElementName = "RegionName")]
		public string RegionName { get; set; }
		[XmlElement(ElementName = "City")]
		public string City { get; set; }
		[XmlElement(ElementName = "ZipCode")]
		public string ZipCode { get; set; }
		[XmlElement(ElementName = "TimeZone")]
		public string TimeZone { get; set; }
		[XmlElement(ElementName = "Latitude")]
		public string Latitude { get; set; }
		[XmlElement(ElementName = "Longitude")]
		public string Longitude { get; set; }
		[XmlElement(ElementName = "MetroCode")]
		public string MetroCode { get; set; }
	}
