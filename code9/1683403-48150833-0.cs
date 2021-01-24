    public class UserAccessToken
    {
        private readonly TokenClient _tokenClient;
        public UserAccessToken(TokenClient tokenClient)
        {
            _tokenClient = tokenClient;
        }
        public async Task<string> GenerateTokenAsync(string username, string password)
        {
            var tokenUrl = "http://localhost:5000/connect/token";
            var tokenResponse = await _tokenClient.RequestResourceOwnerPasswordAsync(username, password, SecurityConfig.PublicApiResourceId);
            if (tokenResponse.IsError)
            {
                throw new AuthenticationFailedException(tokenResponse.Error);
            }
            return tokenResponse.Json.ToString();
        }
    }
