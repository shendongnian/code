    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using IdentityServer3.Core;
    using IdentityServer3.AspNetIdentity;
    using IdentityServer3.Core.Configuration;
    using IdentityServer3.Core.Services;
    namespace ..... {
    public class UserService : AspNetIdentityUserService<IdentityUser, string>
    {
        public UserService(UserManager userMgr) : base(userMgr)
        {
        }
        protected override async Task<IEnumerable<System.Security.Claims.Claim>> GetClaimsFromAccount(IdentityUser user)
        {
            var claims = (await base.GetClaimsFromAccount(user)).ToList();
            // to make sure the email is in the claims
            if (claims.Any(c=>c.Type == Constants.ClaimTypes.Email) && !string.IsNullOrWhiteSpace(user.Email))
            {
                claims.Add(.....);
            }
            return claims;
        }
    }
    ....
    }
