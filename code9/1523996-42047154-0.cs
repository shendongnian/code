    		public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
		{
			var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
			if (loginInfo == null)
			{
				return RedirectToAction("Login");
			}
			// Sign in the user with this external login provider if the user already has a login
			var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
			logger.Info(loginInfo.Email + " attempted an external login with a result of " + result.ToString());
			switch (result)
			{
				case SignInStatus.Success:					
					foreach (Claim c in loginInfo.ExternalIdentity.Claims)
					{
						SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.AddClaim(new Claim(c.Type + "_external", c.Value));
					}
									
					var user = UserManager.FindById(SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId());
					
					user.LastLogin = DateTime.Now.ToUniversalTime();
					await UserManager.UpdateAsync(user);
					return RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.RequiresVerification:
					return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
				case SignInStatus.Failure:
				default:
					// If the user does not have an account, then prompt the user to create an account
					ViewBag.ReturnUrl = returnUrl;
					ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
					return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
			}
		}
