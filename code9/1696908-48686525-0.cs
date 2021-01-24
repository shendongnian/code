	public class WebService: IHttpClient {
		private readonly HttpClient client;
		
		public WebService(IConfiguration configuration) {
			string BaseURL = configuration.GetSection("AppSettings:BaseURL").Value;
			client = new HttpClient();
			client.BaseAddress = new Uri(BaseURL);
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
		
		public async Task<T> GetAsync<T>(string url) {
			var result = default(T);
			var response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode) {
				var json = await response.Content.ReadAsStringAsync();
				result = JsonConvert.DeserializeObject<T>(json);
			}
			return result         
		}
	}
	
