    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Threading.Tasks;
    
    public class ExpectedJwksResponse
        {
            [JsonProperty(PropertyName = "keys")]
            public List<JsonWebKey> Keys { get; set; }
        }
    
    private static async Task<List<SecurityKey>> GetSecurityKeysAsync()
            {
            	// Feel free to use HttpClient or whatever you want to call the endpoint.
                var client = new RestClient("<https://sample-jwks-endpoint.url>");
                var request = new RestRequest(Method.GET);
                var result = await client.ExecuteTaskAsync<ExpectedJwksResponse>(request);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Wasnt 200 status code");
                }
    
                if (result.Data == null || result.Data.Keys == null || result.Data.Keys.Count == 0 )
                {
                    throw new Exception("Couldnt parse any keys");
                }
    
                var keys = new List<SecurityKey>();
                foreach ( var key in result.Data.Keys )
                {
                    keys.Add(key);
                }
                return keys;
            }
    
    private async Task<bool> ValidateToken(token){
    	TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateLifetime = true,
                    ValidIssuer = "https://sample-issuer.com",
                    ValidAudiences = new[] { "https://sample-audience/resource" },
                    IssuerSigningKeys = await GetSecurityKeysAsync()
    		    };
        var user = null as System.Security.Claims.ClaimsPrincipal;
        SecurityToken validatedToken;
        try
        {
            user = handler.ValidateToken(token, validationParameters, out validatedToken);
        }
        catch ( Exception e )
        {
            Console.Write($"ErrorMessage: {e.Message}");
            return false;
        }
        var readToken = handler.ReadJwtToken(token);
        var claims = readToken.Claims;
        return true;
    }
