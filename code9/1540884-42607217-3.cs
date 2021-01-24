    [HttpPost]
    public IActionResult DeleteAccessToken([FromBody]User user)
    {
    	if (Context.Users.Any(u => u.Id == user.Id))
    	{
    		Context.AccessTokens.Remove(user.AccessToken);
    		return Ok();
    	}
    	else
    	{
    		return Unauthorized();
    	}
    }
