    public ActionResult EmailActivation()
    {
        ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;
        return View("EmailActivation", 
                new EmailActivationFormViewModel
                {
                    ReturnUrl = Request.ApplicationPath,
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                    IsSelfRegistrationAllowed = IsSelfRegistrationEnabled(),
                    MultiTenancySide = AbpSession.MultiTenancySide
                });
    }
