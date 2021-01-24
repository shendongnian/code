    [HttpPost]
    [AllowAnonymous]
    [Produces("application/json")]
    public async Task<object> GetToken([FromBody] LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if (result.Succeeded)
        {
            var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            return await GenerateJwtTokenAsync(model.Email, appUser);
        }
        throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
    }
    // create token
    private async Task<object> GenerateJwtTokenAsync(string email, ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
        }
        // get options
        var jwtAppSettingOptions = _configuration.GetSection("JwtIssuerOptions");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions["JwtKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtAppSettingOptions["JwtExpireDays"]));
        var token = new JwtSecurityToken(
            jwtAppSettingOptions["JwtIssuer"],
            jwtAppSettingOptions["JwtIssuer"],
            claims,
            expires: expires,
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
