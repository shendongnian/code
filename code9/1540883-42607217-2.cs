    [HttpPost]
    public IActionResult DeleteAccessToken([FromBody]User user)
    {
        // Requires System.Linq
    	if (Context.Users.Any(u => u.Id == user.Id))
    	{
    		var accessTokenEntity = Context.AccessTokens.Find(user.AccessToken.Id); // Find the entity of the accesstoken (I tried also directly by accessing the navigation property of user entity)
    		Context.AccessTokens.Remove(accessTokenEntity);
            // NOTE: You re not saving?
    		return Ok();
    	}
    	else
    	{
    		return Unauthorized();
    	}
    }
