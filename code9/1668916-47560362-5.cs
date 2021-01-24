    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        string userTZ = model.UserTZ,
               userTZOffset = model.UserTZOffset;
        ...
    }
