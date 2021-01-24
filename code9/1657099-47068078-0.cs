    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Register([FromBody]RegisterModel model)
    {
    	// Code
    }
