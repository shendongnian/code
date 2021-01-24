    public override async Task GrantResourceOwnerCredentials(
    		OAuthGrantResourceOwnerCredentialsContext context) {
    		context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    		using (var authRepo = AuthRepository.Create()) {
    			var findUserResult = await authRepo.FindUser(context.UserName, context.Password);
    			if (findUserResult == UserModel.NoUser) {
    				context.SetError("error", "User not found.");
    			} else {
    				var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    				identity.AddClaim( // this is important, [PrivateAttribute] relies on this
    					new Claim(CONSTANTS.USER_ID_KEY, findUserResult.ID.ToString()));
    				context.Validated(identity);
    			}
    		}
    	}
