        const int _downloadImageTimeoutInSeconds = 15;
    	readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(_downloadImageTimeoutInSeconds) };
		async Task<byte[]> DownloadImageAsync(string imageUrl)
		{
			try
			{
				using (var httpResponse = await _httpClient.GetAsync(imageUrl))
			    {
				    if (httpResponse.StatusCode == HttpStatusCode.OK)
				    {
					    return await httpResponse.Content.ReadAsByteArrayAsync();
				    }
				    else
				    {
					    //Url is Invalid
                        return null;
				    }
			    }
			 }
			 catch (Exception e)
			 {
			     //Handle Exception
                 return null;
			 }
		}
