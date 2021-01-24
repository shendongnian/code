    protected ActionResult GoBack()
    {
        try
        {
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        catch (Exception ex)
        {
           TempData["ErrorHeader"] = "Some kind of Error header";
           TempData["ErrorMessage"] = "Some kind of Error message";
           logger.Error("Add ErrorMessage here",ex);
           return RedirectToAction("index", "Home");
        }
    }
