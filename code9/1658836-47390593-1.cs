    string idToken = "<the id_token that was returned from the Token endpoint>";
    List<SecurityKey> keys = this.GetSecurityKeys(jsonWebKeySet);
    var parameters = new TokenValidationParameters
                     {
                          ValidateAudience = true,
                          ValidAudience = tokenValidationParams.Audience,
                          ValidateIssuer = true,
                          ValidIssuer = tokenValidationParams.Issuer,
                          ValidateIssuerSigningKey = true,
                          IssuerSigningKeys = keys,
                          NameClaimType = NameClaimType,
                          RoleClaimType = RoleClaimType
                      };
    
     var handler = new JwtSecurityTokenHandler();
     handler.InboundClaimTypeMap.Clear();
    
     SecurityToken jwt;
     ClaimsPrincipal claimsPrincipal = handler.ValidateToken(idToken, parameters, out jwt);
    
     // validate nonce
     var nonceClaim = claimsPrincipal.FindFirst("nonce")?.Value ?? string.Empty;
    
     if (!string.Equals(nonceClaim, "<add nonce value here>", StringComparison.Ordinal))
     {
          throw new AuthException("An error occurred during the authentication process - invalid nonce parameter");
     }
    
     return claimsPrincipal;
