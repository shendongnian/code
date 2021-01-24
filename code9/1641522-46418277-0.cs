    public virtual ActionResult ChangeCulture(string cultureName, string returnUrl = "")
            {
                if (!GlobalizationHelper.IsValidCultureCode(cultureName))
                {
                    throw new AbpException("Unknown language: " + cultureName + ". It must be a valid culture!");
                }
    
                var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureName, cultureName));
    
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    cookieValue,
                    new CookieOptions {Expires = Clock.Now.AddYears(2)}
                );
    
                if (AbpSession.UserId.HasValue)
                {
                    SettingManager.ChangeSettingForUser(
                        AbpSession.ToUserIdentifier(),
                        LocalizationSettingNames.DefaultLanguage,
                        cultureName
                    );
                }
    
                if (Request.IsAjaxRequest())
                {
                    return Json(new AjaxResponse());
                }
    
                if (!string.IsNullOrWhiteSpace(returnUrl) && AbpUrlHelper.IsLocalUrl(Request, returnUrl))
                {
                    return Redirect(returnUrl);
                }
    
                return Redirect("/"); //TODO: Go to app root
    }
