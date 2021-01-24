    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly IAccountService _accountService;
    
        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options, IAccountService accounteService)
        {
            _next = next;
            _options = options.Value;
            _accountService = accounteService;
        }
  
        public Task Invoke(HttpContext context)
        {
            //Check path request
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal)) return _next(context);
  
            //METHOD: POST && Content-Type : x-www-form-urlencode
            if (context.Request.Method.Equals("POST") && context.Request.HasFormContentType)
                return GenerateToken(context);
    
    
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Bad Request");
        }
    
        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];
    
            var identity = await GetIdentity(username, password);
    
            if (identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password");
                return;
            }
    
            var now = DateTime.UtcNow;
   
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.Second.ToString(), ClaimValueTypes.Integer64)
            };
    
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
    
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
    
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds,
                username = username
            };
    
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    
        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
  	        //THIS STEP COULD BE DIFFERENT, I HAVE AN ACCOUNTSERVICE THAT QUERIES MY DB TO CHECK THE USER CREDENTIALS
            var auth = _accountService.Login(username, password).Result;
            return auth
                ? Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }))
                : Task.FromResult<ClaimsIdentity>(null);
        }
    }
