    using System.Security.Claims;
...
        var userRoles = await _userManager.GetRolesAsync(user);
        var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }.Union(userRoles.Select(m => new Claim(ClaimTypes.Role, m)));
