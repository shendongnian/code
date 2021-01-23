    class Program {
      static HttpClient client = new HttpClient();
      static void Main() { RunAsync().Wait(); }
    
      static async Task RunAsync() {
        string encodedJwt = "[TOKEN_TO_BE_VALIDATED]";
        // 1. Get Google signing keys
        client.BaseAddress = new Uri("https://www.googleapis.com/robot/v1/metadata/");
        HttpResponseMessage response = await client.GetAsync(
          "x509/securetoken@system.gserviceaccount.com");
        if (!response.IsSuccessStatusCode) { return; }
        var x509Data = await response.Content.ReadAsAsync<Dictionary<string, string>>();
        SecurityKey[] keys = x509Data.Values.Select(CreateSecurityKeyFromPublicKey).ToArray();
        // 2. Configure validation parameters
        const string FirebaseProjectId = "[FIREBASE_PROJECT_ID]";
        var parameters = new TokenValidationParameters {
          ValidIssuer = "https://securetoken.google.com/" + FirebaseProjectId,
          ValidAudience = FirebaseProjectId,
          IssuerSigningKeys = keys,
        };
        // 3. Use JwtSecurityTokenHandler to validate signature, issuer, audience and lifetime
        var handler = new JwtSecurityTokenHandler();
        SecurityToken token;
        ClaimsPrincipal principal = handler.ValidateToken(encodedJwt, parameters, out token);
        var jwt = (JwtSecurityToken)token;
        // 4.Validate signature algorithm and other applicable valdiations
        if (jwt.Header.Alg != SecurityAlgorithms.RsaSha256) {
          throw new SecurityTokenInvalidSignatureException(
            "The token is not signed with the expected algorithm.");
        }
      }
      static SecurityKey CreateSecurityKeyFromPublicKey(string data) {
        return new X509SecurityKey(new X509Certificate2(Encoding.UTF8.GetBytes(data)));
      }
    }
