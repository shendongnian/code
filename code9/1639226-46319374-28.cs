    public class TokenCache : ITokenCache
    {
        public TokenClient TokenClient { get; set; }
        private readonly string _scope;
        private DateTime _tokenCreation;
        private TokenResponse _tokenResponse;
        public TokenCache(string scope)
        {
            _scope = scope;
        }
        private bool IsTokenValid()
        {
            return _tokenResponse != null && 
                    !_tokenResponse.IsError &&
                    !string.IsNullOrWhiteSpace(_tokenResponse.AccessToken) &&
                    (_tokenCreation.AddSeconds(_tokenResponse.ExpiresIn) > DateTime.UtcNow);
        }
        private async Task RequestToken()
        {
            _tokenResponse = await TokenClient.RequestClientCredentialsAsync(_scope).ConfigureAwait(false);
            _tokenCreation = DateTime.UtcNow;
        }
        public async Task<string> GetAccessToken(bool forceRefresh = false)
        {
            if (!forceRefresh && IsTokenValid()) return _tokenResponse.AccessToken;
            await RequestToken().ConfigureAwait(false);
            if (!IsTokenValid())
            {
                throw new InvalidOperationException("An unexpected token validation error has occured during a token request.");
            }
            return _tokenResponse.AccessToken;
        }
    }
