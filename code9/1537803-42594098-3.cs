    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class DataController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<String>> Secure()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");
    
            var introspectionClient = new IntrospectionClient("https://localhost:44388/connect/introspect", "MyAPI", "TopSecret");
    
            var response = await introspectionClient.SendAsync(new IntrospectionRequest { Token = accessToken });
    
            var isActive = response.IsActive;
            var claims = response.Claims;
    
            return new[] { "secure1", "secure2", $"isActive: {isActive}", JsonConvert.SerializeObject(claims) };
        }
    }
