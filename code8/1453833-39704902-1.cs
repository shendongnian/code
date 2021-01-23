    public class ServerTokenComponent
    {
        private TokenResponse Token { get; set; }
        private DateTime ExpiryTime { get; set; }
        public async Task<TokenResponse> GetToken()
        {
            //use token if it exists and is still fresh
            if (Token != null && ExpiryTime > DateTime.UtcNow)
            {    
                return Token;
            }     
   
            //else get a new token
            var client = new TokenClient("myidpauthority.com","theclientId","thesecret")
            var scopes = "for bar baz";
       
            var tokenResponse = await client.RequestClientCredentialsAsync(scopes);
            if (tokenResponse.IsError || tokenResponse.IsHttpError)
            {
                throw new SecurityTokenException("Could not retrieve token.");
            }
            //set Token to the new token and set the expiry time to the new expiry time
            Token = tokenResponse;
            ExpiryTime = DateTime.UtcNow.AddSeconds(Token.ExpiresIn);
            //return fresh token
            return Token;
        }
    }
