	namespace comp.Services {
		public class CompService {
			static HttpClient client = new HttpClient();
			static CompService() {
				client.BaseAddress = new Uri("someapiurl");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			}
			public async Task<string> GetProductAsync(string path) {
				var resp = string.Empty;
				using(var response = await client.GetAsync(path)) {
					if (response.IsSuccessStatusCode) {
						resp = await response.Content.ReadAsStringAsync();
					}
				}
				return resp;
			}
		}
	}
	
