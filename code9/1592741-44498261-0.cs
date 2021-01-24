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
				BaseAddress = new Uri("http://freegeoip.net/xml")
			};
			var response = await client.GetAsync(userIpAddress);
			// do stuff
		}
		...
	}
