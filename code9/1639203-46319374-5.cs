    public class TokenHttpHandler : DelegatingHandler
    {
        private readonly ITokenCache _tokenCache;
        public TokenHttpHandler(ITokenCache tokenCache)
        {
            InnerHandler = new HttpClientHandler();
            _tokenCache = tokenCache;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await SetAuthHeaderAndSendAsync(request, cancellationToken, false).ConfigureAwait(false);
            //check for 401 and retry
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response = await SetAuthHeaderAndSendAsync(request, cancellationToken, true);
            }
            return response;
        }
        private async Task<HttpResponseMessage> SetAuthHeaderAndSendAsync(HttpRequestMessage request, CancellationToken cancellationToken, bool forceTokenRefresh)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenCache.GetAccessToken(forceTokenRefresh).ConfigureAwait(false));
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
