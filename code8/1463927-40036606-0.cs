    async Task Send(string developerId, string pathToFile, string auth)
        {
        	using (HttpClient c = new HttpClient())
        	{
        		c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth);
        		c.DefaultRequestHeaders.Add("Developer-Id", developerId);
        		var multipartFormDataContent = new MultipartFormDataContent();
        		using (Stream fileStream = new FileStream(pathToFile, FileMode.Open))
        		{
        			multipartFormDataContent.Add(new StreamContent(fileStream));
        			HttpResponseMessage httpResponse = await c.PostAsync(@"https://api.knurld.io/v1/endpointAnalysis/file", multipartFormDataContent);
        			string response = await httpResponse.Content.ReadAsStringAsync();
        		}
        	}
        }
