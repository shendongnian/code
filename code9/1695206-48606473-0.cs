    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
     {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
     var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
     userIdentity.AddClaim(new Claim(ClaimTypes.Name, UserName));
     userIdentity.AddClaim(new Claim(ClaimTypes.Email, Email));               
       // Add custom user claims here
       return userIdentity;
      }
