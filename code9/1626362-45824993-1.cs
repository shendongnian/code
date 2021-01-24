    public override async Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType)
        {
           
              var identityClaims = await base.CreateIdentityAsync(user, authenticationType);
            List<Claim> claimsDelete = new List<Claim>();
            foreach (var claim in identityClaims.Claims)
            {
                if (claim.Type == ClaimTypes.Role)
                    claimsDelete.Add(claim);
            }
            foreach(var claim in claimsDelete)
                identityClaims.TryRemoveClaim(claim);
            var roleStore = new RoleStore();
            var roles = roleStore.GetAll();
            for (int i = 0; i < user.Roles.Count(); i++)
                {
                    if (((ApplicationUserRoles)((List<IdentityUserRole>)user.Roles)[i]).ClientId == this.clientId)
                    {
                       identityClaims.AddClaim(new Claim(ClaimTypes.Role, roles[((List<IdentityUserRole>)user.Roles)[i].RoleId]));
                    }
                
                }
            return identityClaims;
        }
