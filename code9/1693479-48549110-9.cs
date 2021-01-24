    public class ExternalService : IExternalService  {
	    // should consider abstracting this as well but that is another matter
		static Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => new HttpClient());
		
		private HttpClient httpClient {
		    get { return _httpClient.Value; }
		}		
		
        public async Task<MyModel> PostDataAsync(MyData data) {
			var requestJson = JsonConvert.SerializeObject(data);
			var url = "https://jsonplaceholder.typicode.com/posts";
			var content = new StringContent(requestJson, Encoding.UTF8, "application/json")
			var response = await httpClient.PostAsync(url, content);
			var responseContent = await response.Content.ReadAsStringAsync();
			if(response.IsSuccessStatusCode) {
				var responseContent = await response.Content.ReadAsStringAsync();
				var responseModel = JsonConvert.DeserializeObject<MyModel>(responseContent);        
				return responseModel;
			}else 
				return null;
		}
    }
	
