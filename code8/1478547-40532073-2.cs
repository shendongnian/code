    [HttpGet("~/Test")]
    [Authorize(Roles ="Admin")]
    public async Task<string> MyMethod()
    {
    	return await Task<string>.Run(() => "Hello Admin");
    }
