    public T Get<t>(params KeyValuePair<string, string>[] kvps)
    {
    	using (var httpClient = new HttpClient())
    	{
            var url = !kvps.Any() ? _endpoint : $"{_endpoint}?{string.Join("&$", kvps.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)))}";
    		var response = httpClient.GetAsync(url).Result;
    		return JsonConvert.DeserializeObject<t>(response.Content.ReadAsStringAsync().Result);
    	}
    }
