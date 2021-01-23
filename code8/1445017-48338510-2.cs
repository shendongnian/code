    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using WebAPI.Options;
    using System.Security.Principal;
    namespace WebAPI.Controllers
    {
        [EnableCors("<YourCorsPolicyName>")]
        [Route("[api/controller]")]
        public class JWTController : Controller
        {
             private readonly JwtIssuerOptions _jwtOptions;
             private readonly ILogger _logger;
             private readonly JsonSerializerSettings _serializerSettings;
             public JWTController(IOptions<JwtIssuerOptions> jwtOptions, ILoggerFactory loggerFactory)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
            _logger = loggerFactory.CreateLogger<JWTController>();
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            _connectionString = Startup.ConnectionString;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("{username}/{password}")]
        public async Task<IActionResult> Get(string username, string password)
        {
            User user = GetUser(username, password);
            var identity = await GetClaimsIdentity(user);
            if (identity == null)
            {
                _logger.LogInformation($"Invalid username ({username}) or password ({password})");
                return BadRequest("Invalid credentials");
            }
            var claims = new[]
              {
                new Claim("UserID",user.UserId.ToString()),
                new Claim("UserName",user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("DeveloperBoss")
              };
            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            // Serialize and return the response
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            };
            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }
        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }
            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }
            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        /// <summary>
        /// IMAGINE BIG RED WARNING SIGNS HERE!
        /// You'd want to retrieve claims through your claims provider
        /// in whatever way suits you, the below is purely for demo purposes!
        /// </summary>
        private static Task<ClaimsIdentity> GetClaimsIdentity(User user)
        {
            if (user == null)
            {
                // Credentials are invalid, or account doesn't exist
                return Task.FromResult<ClaimsIdentity>(null);
            }
            if (user.UserId == 0)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                    new Claim[] { }));
            }
            return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
              new[]
              {
                new Claim("DeveloperBoss", "IAmBoss")
              }));
        }
    }
