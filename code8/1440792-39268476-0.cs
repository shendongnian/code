    public class MyClaimsFactory : ClaimsIdentityFactory<MyUser, string>
    {
        public override async Task<ClaimsIdentity> CreateAsync(UserManager<MyUser, string> manager, MyUser user, string authenticationType)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            if (user == null)
                throw new ArgumentNullException("user");
        
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(authenticationType, this.UserNameClaimType, this.RoleClaimType);
            claimsIdentity.AddClaim(new Claim(this.UserIdClaimType, this.ConvertIdToString(user.Id), "http://www.w3.org/2001/XMLSchema#string"));
            claimsIdentity.AddClaim(new Claim(this.UserNameClaimType, user.UserName, "http://www.w3.org/2001/XMLSchema#string"));
            claimsIdentity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"));
        
            if (!user.IsGuest)
            {
                if (manager.SupportsUserSecurityStamp)
                    claimsIdentity.AddClaim(new Claim(this.SecurityStampClaimType, await manager.GetSecurityStampAsync(user.Id).WithCurrentCulture<string>()));
        
                if (manager.SupportsUserRole)
                {
                    IList<string> list = await manager.GetRolesAsync(user.Id).WithCurrentCulture<IList<string>>();
                    foreach (string current in list)
                    {
                        claimsIdentity.AddClaim(new Claim(this.RoleClaimType, current, "http://www.w3.org/2001/XMLSchema#string"));
                    }
                }
                if (manager.SupportsUserClaim)
                    claimsIdentity.AddClaims(await manager.GetClaimsAsync(user.Id).WithCurrentCulture<IList<Claim>>());
            }
        
            return claimsIdentity;
        }
    }
