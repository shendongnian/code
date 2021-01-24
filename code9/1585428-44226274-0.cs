    public class RestService : IRestService {
        private static HttpClient client = new HttpClient();
        static RestService() {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMilliseconds(Constants.DefaultTimeOut);
        }
        public async Task<StellaData> GetStellConfigData() {
            try {                
                //Add the API
                using(var response = await client.GetAsync(new Uri(Constants.mUrl))) {
                    if (response.IsSuccessStatusCode) {
                        return await response.Content.ReadAsAsync<StellaData>();
                    }
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
