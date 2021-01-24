    public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
    {
        // TODO: Handle AddshopperToBasketException in UserService.AuthenticateLocalAsync
        try
        {
            var user = new shopper(_dbConnLib, context.UserName, context.Password);
            var claims = new List<Claim> { new Claim("acr_level", "level 0"), new Claim("amr", "anonymous") };
            context.AuthenticateResult = new AuthenticateResult(user.shopperid, user.MemberDetail.billToAddress.FirstName, claims);
        }
        catch(shopperInitFromException ex)
        {
            context.AuthenticateResult = null;  // Indicates username/password failure
        }
        return Task.FromResult(0);
    }
