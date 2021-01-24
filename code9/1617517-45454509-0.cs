    public virtual async Task<ActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
    {
        //try to authenticate via login and password
        var result = await _signInManagerService.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, shouldLockout: true);
        switch (result)
        {
            //try to authenticate via web-service
            case Microsoft.AspNet.Identity.Owin.SignInStatus.Failure:
                CustomerServiceClient clientToService = new CustomerServiceClient();
                var customerData = clientToService.LoadCustomerData(loginViewModel.Email, loginViewModel.Password);
                ClaimsIdentity identity = CustomerIdentityHelper.CreateIdentity(customerData);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginViewModel.RememberMe}, identity);
                break;
            default:
                return View(loginViewModel);
        }
    }
