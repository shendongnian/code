        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                DomainUser = context.Parameters["DomainUser"] == "true";
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
