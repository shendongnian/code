    return new AuthenticationTicket(principal.Identities.First(), new AuthenticationProperties
    				{
    					IssuedUtc = validatedToken.ValidFrom,
    					ExpiresUtc = validatedToken.ValidTo
    				});
