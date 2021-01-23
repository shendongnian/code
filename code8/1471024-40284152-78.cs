csharp
public class TokenController : ApiController
{
    // This is naive endpoint for demo, it should use Basic authentication
    // to provide token or POST request
    [AllowAnonymous]
    public string Get(string username, string password)
    {
        if (CheckUser(username, password))
        {
            return JwtManager.GenerateToken(username);
        }
        throw new HttpResponseException(HttpStatusCode.Unauthorized);
    }
    public bool CheckUser(string username, string password)
    {
        // should check in the database
        return true;
    }
}
This is naive action, in production you should use POST request or Basic Authentication endpoint to provide JWT token.
How to generate the token based on `username`?
You can use the NuGet package called `System.IdentityModel.Tokens.Jwt` from MS to generate the token, or even another package if you like. In the demo, I use `HMACSHA256` with `SymmetricKey`:
csharp
/// <summary>
/// Use the below code to generate symmetric Secret Key
///     var hmac = new HMACSHA256();
///     var key = Convert.ToBase64String(hmac.Key);
/// </summary>
private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
public static string GenerateToken(string username, int expireMinutes = 20)
{
    var symmetricKey = Convert.FromBase64String(Secret);
    var tokenHandler = new JwtSecurityTokenHandler();
    var now = DateTime.UtcNow;
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, username)
        }),
        Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
        
        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(symmetricKey), 
            SecurityAlgorithms.HmacSha256Signature)
    };
    var stoken = tokenHandler.CreateToken(tokenDescriptor);
    var token = tokenHandler.WriteToken(stoken);
    return token;
}
The endpoint to provide the JWT token is done, now, how to validate the JWT when the request comes, in the demo I have built 
`JwtAuthenticationAttribute` which inherits from `IAuthenticationFilter`, more detail about authentication filter in [here](https://www.asp.net/web-api/overview/security/authentication-filters).
With this attribute, you can authenticate any action, you just put this attribute on that action. 
csharp
public class ValueController : ApiController
{
    [JwtAuthentication]
    public string Get()
    {
        return "value";
    }
}
You also can use OWIN middleware or DelegateHander if you want to validate all incoming request for your WebApi (not specific on Controller or action)
Below is the core method from authentication filter:
csharp
private static bool ValidateToken(string token, out string username)
{
    username = null;
    var simplePrinciple = JwtManager.GetPrincipal(token);
    var identity = simplePrinciple.Identity as ClaimsIdentity;
    if (identity == null)
        return false;
    if (!identity.IsAuthenticated)
        return false;
    var usernameClaim = identity.FindFirst(ClaimTypes.Name);
    username = usernameClaim?.Value;
    if (string.IsNullOrEmpty(username))
       return false;
    // More validate to check whether username exists in system
    return true;
}
protected Task<IPrincipal> AuthenticateJwtToken(string token)
{
    string username;
    if (ValidateToken(token, out username))
    {
        // based on username to get more information from database 
        // in order to build local identity
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
            // Add more claims if needed: Roles, ...
        };
        var identity = new ClaimsIdentity(claims, "Jwt");
        IPrincipal user = new ClaimsPrincipal(identity);
        return Task.FromResult(user);
    }
    return Task.FromResult<IPrincipal>(null);
}
`
The workflow is, using JWT library (NuGet package above) to validate JWT token and then return back `ClaimsPrincipal`. You can perform more validation like check whether user exists on your system and add other custom validations if you want. The code to validate JWT token and get principal back:
csharp
public static ClaimsPrincipal GetPrincipal(string token)
{
    try
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
        if (jwtToken == null)
            return null;
        var symmetricKey = Convert.FromBase64String(Secret);
        var validationParameters = new TokenValidationParameters()
        {
            RequireExpirationTime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
        };
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
        return principal;
    }
    catch (Exception)
    {
        //should write log
        return null;
    }
}
If the JWT token is validated and principal is return, you should build new local identity and put more information into it to check role authorization.
Remember to add `config.Filters.Add(new AuthorizeAttribute());` (default authorization) at global scope in order to prevent any anonymous request to your resources.
You can use Postman to test the demo:
Request token (naive as I mentioned above, just for demo):
