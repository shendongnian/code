        [AllowAnonymous]
        [Route("api/authentication/authenticate")]
        [HttpPost()]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = m_UserManager.Users.FirstOrDefault(x => x.UserName == model.UserName);
                
                if (user == null)
                {
                    ...
                }
                else
                {
                    var result = await m_SignInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        var handler = new JwtSecurityTokenHandler();
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.Name, model.UserName)
                            }),
                            Expires = DateTime.UtcNow.AddHours(2),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(InstanceSettings.JWTKey), SecurityAlgorithms.HmacSha256Signature)
                        };
                        
                        var roles = await m_UserManager.GetRolesAsync(user);
                        
                        AddClaims(tokenDescriptor, roles);
                        
                        var token = handler.CreateToken(tokenDescriptor);
                        var tokenString = handler.WriteToken(token);
                        
                        return ...
                    }
                    else
                    {
                        ...
                    }
                }
            }
            return ...
        }
        
        private static void AddClaims(SecurityTokenDescriptor tokenDescriptor, IList<string> roles)
        {
            if (roles.Any(x => string.Equals(Constants.AdministratorRoleName, x, StringComparison.OrdinalIgnoreCase)))
            {
                tokenDescriptor.Subject.AddClaim(new Claim(PolicyClaims.AdministratorClaim, PolicyClaims.ObtainedClaim));
                
                tokenDescriptor.Subject.AddClaim(new Claim(PolicyClaims.Operation1Claim, PolicyClaims.ObtainedClaim));
                tokenDescriptor.Subject.AddClaim(new Claim(PolicyClaims.Operation2Claim, PolicyClaims.ObtainedClaim));
            }
            ... query the database and add each claim with value PolicyClaims.ObtainedClaim ...
        }
