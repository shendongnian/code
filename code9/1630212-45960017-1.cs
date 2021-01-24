    using System.Net.Http;
    using System.Threading.Tasks;
    ...
	public static async Task<byte[]> DownloadFile(string url)
	{
		using (var client = new HttpClient())
		{
			using (var result = await client.GetAsync(url))
			{
				if (result.IsSuccessStatusCode)
				{
					return await result.Content.ReadAsByteArrayAsync();
				}
			}
		}
		return null;
	}
