            [Route("api/[controller]")]
            public class TokenController : Controller
            {
                private readonly IConfiguration _config;
                private readonly IUserManager _userManager;
        
                public TokenController(IConfiguration configuration, IUserManager userManager)
                {
                    _config = configuration;
                    _userManager = userManager;
                }
        
                [HttpPost("")]
                [AllowAnonymous]
                public IActionResult Login([FromBody] AuthRequest authUserRequest)
                {
                    var user = _userManager.FindByEmail(model.UserName);
        
                    if (user != null)
                    {
                        var checkPwd = _signInManager.CheckPasswordSignIn(user, model.authUserRequest);
                        if (checkPwd)
                        {
                            var claims = new[]
                            {
                                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                            };
        
                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
                            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                            _config["Tokens:Issuer"],
                            claims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: creds);
        
                            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                        }
                    }
        
                    return BadRequest("Could not create token");
                }}
