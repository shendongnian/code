    public ActionResult Register(RegisterModel model, string returnUrl, bool captchaValid, FormCollection form)
            {
                // previous code as it is
    			// added this line to handle validations
    			
    			ModelState.Add("RegisterValidation", null);
    			//If we got this far, something failed, redisplay form
    			PrepareCustomerRegisterModel(model, true, customerAttributesXml);
    
    			var loginModel = new LoginModel();
    			loginModel.UsernamesEnabled = _customerSettings.UsernamesEnabled;
    			//loginModel.CheckoutAsGuest = checkoutAsGuest.GetValueOrDefault();
    			loginModel.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnLoginPage;
    
    			return View("Login", new LoginRegisterModel { RegisterModel = model, LoginModel = loginModel });
    		}
