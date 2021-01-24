    public ActionResult Login(bool? checkoutAsGuest)
            {
                var loginModel= new LoginModel();
                loginModel.UsernamesEnabled = _customerSettings.UsernamesEnabled;
                loginModel.CheckoutAsGuest = checkoutAsGuest.GetValueOrDefault();
                loginModel.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnLoginPage;
    
    			var registerModel = new RegisterModel();
    			PrepareCustomerRegisterModel(registerModel, false);
    			registerModel.Newsletter = _customerSettings.NewsletterTickedByDefault;
    
    			return View(new LoginRegisterModel { LoginModel = , RegisterModel = registerModel });
    		}
