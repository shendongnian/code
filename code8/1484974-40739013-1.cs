    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(string url, TRequest request)
    {
    	ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
    	
    	using (var handler = new HttpClientHandler() {})
    	{
    		using (var client = new HttpClient(handler))
    		{
    			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 
    			var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
    			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
    
    			var processResult = await client.PostAsync(url, httpContent);
    			var responseBody = processResult.Content.ReadAsStringAsync().Result;
    			
    			return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody);
    		}
    	}
    }
