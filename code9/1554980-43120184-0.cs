    void Main()
    {
    	var test = SendGetRequest("http://www.google.com");
    	test.Dump();
    }
    
    public async static Task<string> SendGetRequest(string url)
    {
    	try
    	{
    		var uri = new Uri(url);
    		HttpClient client = new HttpClient();
    		//Preparing to have something to read
    		var formContent = new FormUrlEncodedContent(new[]
    				{
    					new KeyValuePair<string, string>("OperationType", "eaf7d94356e7fd39935547f6f15e1c4c234245e4")
    				});
    
    		HttpResponseMessage response = await client.PostAsync(uri, formContent);
    
    		#region - - Envio anterior (NO FUNCIONO, SIN USO) - -
    		//var stringContent = new StringContent("markString");
    		//var sending = await client.PostAsync(url, stringContent);
    
    		//MainActivity.ConsoleData = await client.PostAsync(url, stringContent);
    		#endregion
    
    		//Reading data
    		//var response = await client.GetAsync(url);
    		var json = await response.Content.ReadAsStringAsync();
    	
    		return json;
    	}
    	catch (System.Exception ex)
    	{
    		Console.WriteLine("Error: " + ex.ToString());
    		return string.Empty;
    	}
    
    }
