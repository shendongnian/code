    using (var client = getHttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
    		Dictionary<string, string> dictionary = new Dictionary<string, string>();
    		var rx = new Regex(@"(.*?)\s*=\s*([^\s]+)");
    		foreach (Match m in rx.Matches(data))
    		{
    			dictionary.Add(m.Groups[1].ToString(), m.Groups[2].ToString());
    		}
        }
        else
        {
            //TODO: Need to handle error scenario
        }
    }
