		async Task<byte[]> DownloadImageAsync(string imageUrl)
		{
            int downloadTimeoutInSeconds = 15;
			try
			{
                using(var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(downloadTimeoutInSeconds) })
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
		}
