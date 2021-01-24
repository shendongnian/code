    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public JsonResult IsEmailAvailable(string emailAddress)
    {
        if (!_context.Users.Any(c => c.EmailAddress == emailAddress))
        {
             return Json(true, JsonRequestBehavior.AllowGet);
        }
        return Json("Email address already taken" , JsonRequestBehavior.AllowGet);
    }
