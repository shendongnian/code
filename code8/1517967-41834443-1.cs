    [HttpPost]
    public async Task<IActionResult> LoginAsync([FromBody]LoginModel login, [FromServices]ILoginService loginService) 
    {
        // Validate input, only rough validation. No business validation here
        if(!Model.IsValid) 
        {
            return BadRequest(Model);
        }
        bool success = await loginService.Login(model);
        if(success) 
        {
            return RedirectTo("Login");
        }
        return Unauthorized();
    }
