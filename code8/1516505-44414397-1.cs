    public class JwtBearerBacker
    {
        public JwtBearerOptions Options { get; private set; }
        public JwtBearerBacker(JwtBearerOptions options)
        {
            this.Options = options;
        }
        public bool IsJwtValid(string token)
        {
            List<Exception> validationFailures = null;
            SecurityToken validatedToken;
            foreach (var validator in Options.SecurityTokenValidators)
            {
                if (validator.CanReadToken(token))
                {
                    ClaimsPrincipal principal;
                    try
                    {
                        principal = validator.ValidateToken(token, Options.TokenValidationParameters, out validatedToken);
                    }
                    catch (Exception ex)
                    {
                        // Refresh the configuration for exceptions that may be caused by key rollovers. The user can also request a refresh in the event.
                        if (Options.RefreshOnIssuerKeyNotFound && Options.ConfigurationManager != null
                            && ex is SecurityTokenSignatureKeyNotFoundException)
                        {
                            Options.ConfigurationManager.RequestRefresh();
                        }
                        if (validationFailures == null)
                            validationFailures = new List<Exception>(1);
                        validationFailures.Add(ex);
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }
    }
