    [Authorize]
    [HttpGet]
    public ActionResult GetSelectedClientID()
    {
       selectedClientId = HelperMethods.GetClientId();
       return Content(selectedClientId);
    }
