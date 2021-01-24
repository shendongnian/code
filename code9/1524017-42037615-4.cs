    private async Task<List<Claim>> GetValidClaims(ApplicationUser user)
    {
        IdentityOptions _options = new IdentityOptions();
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
            };
        var userClaims = await _userManager.GetClaimsAsync(user);
        var userRoles = await _userManager.GetRolesAsync(user);
        claims.AddRange(userClaims);
        foreach (var userRole in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            var role = await _roleManager.FindByNameAsync(userRole);
            if(role != null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach(Claim roleClaim in roleClaims)
                {
                    claims.Add(roleClaim);
                }
            }
        }
        return claims;
    }
