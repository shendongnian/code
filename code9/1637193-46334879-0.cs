    public class CustomMessageHandler: DelegatingHandler
    {
        private string _accessToken;
        private string _refreshToken;
        public CustomMessageHandler(string accessToken, string refreshToken)
        {
            _accessToken = accessToken;
            _refreshToken = refreshToken;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response= await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                /* TODO:
                 * 1. Retrieve the new access_token via the refresh_token
                 * 2. Update the current field _accessToken
                 * 3. Retry the previous failed request    
                 */
            }
            return response;
        }
    }
