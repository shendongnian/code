    public class LoginController : Controller
    {
        private ConfigurationSettings Config { get; }
        
        public LoginController(IOption<ConfigurationSettings> jwtOptions, ... /* other deps */)
        {
            Config = jwtOptions.Value;
        }
        
        public JsonResult GenerateToken([FromBody] LoginModel model)
        {
            ...
            // this access the options injected in constructor
            var token = new JwtSecurityToken(Config.Issuer, Config.Audience, claims, expires: DateTime.Now.AddSeconds(Config.TokenExpire), signingCredentials: creds);
            ...
        }
    }
