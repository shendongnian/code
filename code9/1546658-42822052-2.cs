    public async Task<ActionResult> Login(LoginModel model, string returnUrl)
    {
       if (ModelState.IsValid)
       {
          bool result = _activeDirectoryService.ValidateCredentials(
             model.Domain, model.UserName, model.Password);
          if (result)
          {
              ...
          }
       }
       ...
    }
