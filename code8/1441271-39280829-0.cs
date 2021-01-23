    if (signInResult.Succeeded)
    {
       if (string.IsNullOrWhiteSpace(returnUrl))
       {
          return RedirectToAction("Timesheets", "App");
       }
       else
       {
          return Redirect(returnUrl);
       }
    }
