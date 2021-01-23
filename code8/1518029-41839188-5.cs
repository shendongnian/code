    async Task<Row> GetRows()
    {
    	XmlSerializer xs = new XmlSerializer(typeof(WebRates));
    
    	using (HttpClient client = new HttpClient())
    	{
    		using (StreamReader reader = new StreamReader(await client.GetStreamAsync("http://www.forex.se/ratesxml.asp?id=492")))
    		{
    			WebRates root = (WebRates)xs.Deserialize(reader);
    			return root.Rows.FirstOrDefault(x => x.Code == "USD");
    		}
    	}
    }
