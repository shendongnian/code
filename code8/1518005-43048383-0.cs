    public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
    		{
    
    			// Change auth ticket for refresh token requests
    			var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
    			//newIdentity.AddClaim(new Claim("newClaim", "newValue"));
    
    			var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
    			context.Validated(newTicket);
    
    			return Task.FromResult<object>(null);
    		}
