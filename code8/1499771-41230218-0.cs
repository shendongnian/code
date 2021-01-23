    new CookieAuthenticationProvider
    {  
       OnValidateIdentity = SecurityStampValidator
          .OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
          **validateInterval: TimeSpan.FromMinutes(30),**
          regenerateIdentity: (manager, user)
          => user.GenerateUserIdentityAsync(manager))
    }
