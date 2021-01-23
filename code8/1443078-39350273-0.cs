    [Route("api/Account/Login")]
	[HttpPost]
	public object Login(User userModel) {
		User user = ...;
		string token = CreateTokenForUser(user);
		if (user != null) {
			// return user and token back 
			return new {User = user, Token = token};
		} else {
			throw new HttpResponseException(HttpStatusCode.Unauthorized);
		}
	}
