    public override async Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType)
        {
           
            var identityClaims = await base.CreateIdentityAsync(user, authenticationType);
            foreach (var claim in identityClaims.Claims)
            {
                if (claim.Type == ClaimTypes.Role)
                    identityClaims.RemoveClaim(claim);
            }
                for (int i = 0; i < user.Roles.Count(); i++)
                {
                    if (((ApplicationUserRoles)((List<IdentityUserRole>)user.Roles)[i]).ClientId != this.clientId)
                    {
                        new Claim(ClaimTypes.Role, ((List<IdentityUserRole>)user.Roles)[i].RoleId);
                    }
                    
                    ((List<IdentityUserRole>)user.Roles).RemoveAt(i);
                }
            return identityClaims;
        }
