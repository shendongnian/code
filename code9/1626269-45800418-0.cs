    public class ApiService {
        private IHttpClient _http;
        private string _login_url;
        public ApiService(IHttpClient httpClient) {
            this._http = httpClient;
        }
        public async Task<bool> LoginAsync(string user, string password) {
            var body = new { Username = user, Password = password };
            try {
                var response = await _http.PostAsync(_login_url, JsonConvert.SerializeObject(body), null);
                return response.StatusCode == HttpStatusCode.OK;
            } catch (Exception ex) {
                //Logger.Error(ex);
                return false;
            }
        }
    }
