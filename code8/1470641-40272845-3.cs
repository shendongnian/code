    public IActionResult Login(YourViewModel model)
    {
        if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
        {
    
        }
    }
    
    public IActionResult Register(YourViewModel model)
    {
        if (!string.IsNullOrEmpty(model.UserName) &&
            !string.IsNullOrEmpty(model.Password) &&
            !string.IsNullOrEmpty(model.FirstName) &&
            !string.IsNullOrEmpty(model.Email))
        {
    
        }
    }
