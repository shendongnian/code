     /// <summary>
            /// Login provides API to verify user and returns authentication token.
            /// API Path:  api/account/login
            /// </summary>
            /// <param name="paramUser">Username and Password</param>
            /// <returns>{Token: [Token] }</returns>
            [HttpPost("login")]
            [AllowAnonymous]
            public async Task<IActionResult> Login([FromBody] UserRequestVM paramUser, CancellationToken ct)
            {
    
                var result = await UserApplication.PasswordSignInAsync(paramUser.Email, paramUser.Password, false, lockoutOnFailure: false);
    
                if (result.Succeeded)
                {
                    UserRequestVM request = new UserRequestVM();
                    request.Email = paramUser.Email;
    
    
                    ApplicationUser UserDetails = await this.GetUserByEmail(request);
                    List<ApplicationClaim> UserClaims = await this.ClaimApplication.GetListByUser(UserDetails);
    
                    var Claims = new ClaimsIdentity(new Claim[]
                                    {
                                        new Claim(JwtRegisteredClaimNames.Sub, paramUser.Email.ToString()),
                                        new Claim(UserId, UserDetails.UserId.ToString())
                                    });
    
    
                    //Adding UserClaims to JWT claims
                    foreach (var item in UserClaims)
                    {
                        Claims.AddClaim(new Claim(item.ClaimCode, string.Empty));
                    }
    
                    var tokenHandler = new JwtSecurityTokenHandler();
                      // this information will be retrived from you Configuration
                    //I have injected Configuration provider service into my controller
                    var encryptionkey = Configuration["Jwt:Encryptionkey"];
                    var key = Encoding.ASCII.GetBytes(encryptionkey);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Issuer = Configuration["Jwt:Issuer"],
                        Subject = Claims,
    
                    // this information will be retrived from you Configuration
                    //I have injected Configuration provider service into my controller
                        Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(Configuration["Jwt:ExpiryTimeInMinutes"])),
    
                        //algorithm to sign the token
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    
                    };
    
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
    
                    return Ok(new
                    {
                        token = tokenString
                    });
                }
    
                return BadRequest("Wrong Username or password");
            }
