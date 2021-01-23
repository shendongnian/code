    static async Task<string> GetData()
		{
			using (WebClient webClient = new WebClient())
			{
				return await webClient.UploadStringTaskAsync(new Uri("http://www.facebook.com/"), "POST", string.Empty);
			}
		}
