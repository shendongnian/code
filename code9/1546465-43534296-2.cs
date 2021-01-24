    public ActionResult Register()
            {
                //check whether registration is allowed
                if (_customerSettings.UserRegistrationType == UserRegistrationType.Disabled)
                    return RedirectToRoute("RegisterResult", new { resultId = (int)UserRegistrationType.Disabled });
    
                var model = new RegisterModel();
                PrepareCustomerRegisterModel(model, false);
                model.Newsletter = _customerSettings.NewsletterTickedByDefault;
    
    			var loginModel = new LoginModel();
    			loginModel.UsernamesEnabled = _customerSettings.UsernamesEnabled;
    			loginModel.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnLoginPage;
    
    			return View("Login", new LoginRegisterModel { RegisterModel = model, LoginModel = loginModel });
            }
