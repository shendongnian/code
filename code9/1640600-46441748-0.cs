    public AuthenticationTicket Unprotect(string protectedText)
    {           
          try
          {
              var handler = new JwtSecurityTokenHandler();
        
              AppContext = new AppContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
                        {
                            EventLogPriority = Properties.Settings.Default.EventLogPriority
                        };
        
              SecurityToken validToken;
        
              _validationParameters.IssuerSigningKey = new SymmetricSecurityKey(TextEncodings.Base64Url.Decode(Secret));
                        ClaimsPrincipal principal = handler.ValidateToken(protectedText, _validationParameters, out validToken);
        
               var validJwt = validToken as JwtSecurityToken;
        
               if (validJwt == null)
               {
                   throw new ArgumentException("Invalid JWT");
               }
        
               ClaimsIdentity identity = principal.Identities.FirstOrDefault();
               return new AuthenticationTicket(identity, new AuthenticationProperties());
         }            
         catch (SecurityTokenException ex)
         {
              var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Access Token is manipulated" };
                        throw new HttpResponseException(msg);
         }
    }
