    public ActionResult Login(LoginModel model, string returnUrl, bool captchaValid)
            {
    		// Previous code as it is
	        // Important! I Added this new line - to handle validation problems
			ModelState.Add("LoginValidation", null);
			//If we got this far, something failed, redisplay form
			model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            model.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnLoginPage;
			var registerModel = new RegisterModel();
			PrepareCustomerRegisterModel(registerModel, false);
			//enable newsletter by default
			registerModel.Newsletter = _customerSettings.NewsletterTickedByDefault;
			
			return View(new LoginRegisterModel { LoginModel = model, RegisterModel = registerModel });
        } 
