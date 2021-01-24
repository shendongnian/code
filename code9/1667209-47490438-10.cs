    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
       var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
       // how do you add claim???
       if(Groups.Any()) { //assuming this is a navigation property
           //create a claim type/name/key
           //replace with you desired key. Store in a constant for later use
           var claimName = Constants.Security.ClaimTypes.ProjectGroup; 
           //create claims from current groups.
           var claims = Groups.SelectMany(g => g.Projects.Select(x => x.Id))
               .Select(id => new System.Security.Claims.Claim(claimName, id.ToString()));
           userIdentity.AddClaims(claims);
       }
       return userIdentity;
     }
