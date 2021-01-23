    var x = await POSTDataHttpContent("test", "http://api/");
    public async Task<HttpResponseMessage> POSTDataHttpContent(
        string jsonString, string webAddress)
    {
    	using (HttpClient client = new HttpClient())
    	{
    		StringContent stringContent = new StringContent(jsonString);
    		HttpResponseMessage response = await client.PostAsync(
    		webAddress,
    		stringContent);
    
    		Console.WriteLine("response is: " + response);
    
    		return response;
    	}
    }
