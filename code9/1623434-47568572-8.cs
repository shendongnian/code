    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserContext _context;
        public AccountController(UserContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [Route("api/token")]
        [HttpPost]
        public async Task<IActionResult> Token([FromBody]User user)
        {
            if (!ModelState.IsValid) return BadRequest("Token failed to generate");
            var userIdentified = _context.Users.FirstOrDefault(u => u.Username == user.Username);
                if (userIdentified == null)
                {
                    return Unauthorized();
                }
                user = userIdentified;
            //Add Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
                new Claim(JwtRegisteredClaimNames.Sub, "data"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md")); //Secret
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("me",
                "you",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return Ok(new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = DateTime.Now.AddMinutes(30),
                token_type = "bearer"
            });
        }
    }
