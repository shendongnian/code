		[HttpPost, Route("Login")]
		public IActionResult LogIn([FromBody]LoginModel login) {
		  //...
		  var identity = new ClaimsIdentity("MyCookie");
		  //add the login as the name of the user
		  identity.AddClaim(new Claim(ClaimTypes.Name, login.Login));
		  //add a list of roles
		  foreach (Role r in someList.Roles) {
			identity.AddClaim(new Claim(ClaimTypes.Role, r.Name));
		  }
		  var principal = new ClaimsPrincipal(identity);
		  HttpContext.Authentication.SignInAsync("MyCookie", principal).Wait();
		  return Ok();
		}
