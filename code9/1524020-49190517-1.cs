    [HttpPost]
    public IActionResult GetToken([FromBody]Credentials credentials)
    {
        // TODO: Add here some input values validations
        User user = _userRepository.GetUser(credentials.Email, credentials.Password);
        if (user == null)
            return BadRequest();
        ClaimsIdentity identity = GetClaimsIdentity(user);
        return Ok(new AuthenticatedUserInfoJsonModel
        {
            UserId = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Token = GetJwtToken(identity)
        });
    }
    private ClaimsIdentity GetClaimsIdentity(User user)
    {
        // Here we can save some values to token.
        // For example we are storing here user id and email
        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");
        // Adding roles code
        // Roles property is string collection but you can modify Select code if it it's not
        claimsIdentity.AddClaims(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
        return claimsIdentity;
    }
    private string GetJwtToken(ClaimsIdentity identity)
    {
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: AuthJwtTokenOptions.Issuer,
            audience: AuthJwtTokenOptions.Audience,
            notBefore: DateTime.UtcNow,
            claims: identity.Claims,
            // our token will live 1 hour, but you can change you token lifetime here
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
            signingCredentials: new SigningCredentials(AuthJwtTokenOptions.GetSecurityKey(), SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
