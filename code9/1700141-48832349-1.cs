    [HttpPost("RegisterUser")]
    [AllowAnonymous]
    [ValidateModel]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterViewModel vmodel)
    {
        ...
    }
