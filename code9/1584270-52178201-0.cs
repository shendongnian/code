    public Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            
            var requestIPAddress = context.Ticket.Identity.FindFirst(ClaimTypes.Dns)?.Value;
            
            if (requestIPAddress == null)
                context.SetError("Token Invalid", "The IP Address not right");
                
            string clientAddress = JWTHelper.GetClientIPAddress();
            if (!requestIPAddress.Equals(clientAddress))
                context.SetError("Token Invalid", "The IP Address not right");
            return Task.FromResult<object>(null);
        }
