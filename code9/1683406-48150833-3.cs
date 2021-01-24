    public class LoginController : Controller
    {
        private readonly UserAccessToken _userAccessToken;
        public LoginController(UserAccessToken userAccessToken)
        {
            _userAccessToken = userAccessToken;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel user)
        {
            var accessToken = await _userAccessToken .GenerateTokenAsync(user.Username, user.Password);
            var loginToken = JsonConvert.DeserializeObject(accessToken);
            return Ok(loginToken);
        }
    }
