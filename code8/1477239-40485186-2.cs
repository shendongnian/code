    [HttpPost, Route("LogIn")]
    public IActionResult LogIn([FromServices] UserService userService, [FromBody]LoginModel login) {
      using (var session = SessionFactory.OpenSession())
      using (var transaction = session.BeginTransaction()) {
        User user = userService.Login(session, login.UserName, login.PassWord);
        if (user == null)
          return BadRequest("Invalid user");
        var identity = new ClaimsIdentity("FileSystem");
        identity.AddClaim(new Claim(ClaimTypes.Name, login.UserName));
        foreach (Role r in user.Roles) {
          identity.AddClaim(new Claim(ClaimTypes.Role, r.Nome));
        }
        var principal = new ClaimsPrincipal(identity);
        HttpContext.Authentication.SignInAsync("FileSystem", principal).Wait();
      }
      return Ok();
    }
