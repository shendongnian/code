    public class RestClient
    {
        public bool IsDisposed { get; private set; }
        public HttpClient BaseClient { get; private set; }
    
        private readonly string jsonMediaType = "application/json";
    
        public RestClient(string hostName, string token, HttpClient client)
        {
            BaseClient = client;
            BaseClient.BaseAddress = new Uri(hostName);
            BaseClient.DefaultRequestHeaders.Add("Authorization", token);
        }
    
        public async Task<string> PostAsync(string resource, string postData)
        {
            StringContent strContent = new StringContent(postData, Encoding.UTF8, jsonMediaType);
            HttpResponseMessage responseMessage = await BaseClient.PostAsync(resource, strContent).ConfigureAwait(false);
            responseMessage.RaiseExceptionIfFailed();
            return await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    
        public async Task<string> SendAsync(HttpMethod method, string resource, string token, string postData)
        {
            var resourceUri = new Uri(resource, UriKind.Relative);
            var uri = new Uri(BaseClient.BaseAddress, resourceUri);
            HttpRequestMessage request = new HttpRequestMessage(method, uri);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            if (!string.IsNullOrEmpty(postData))
            {
                request.Content = new StringContent(postData, Encoding.UTF8, jsonMediaType);
            }
    
            HttpResponseMessage response = BaseClient.SendAsync(request).Result;
            response.RaiseExceptionIfFailed();
            return await response.Content.ReadAsStringAsync();
        }
    
        protected virtual void Dispose(bool isDisposing)
        {
            if (IsDisposed)
            {
                return;
            }
            if (isDisposing)
            {
                BaseClient.Dispose();
            }
            IsDisposed = true;
        }
    
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        ~RestClient()
        {
            Dispose(false);
        }
    
    
    }
