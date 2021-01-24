    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Administrator")]
    public async Task<IActionResult> Register([FromBody]RegisterModel model)
    {
    	// Code
    }
