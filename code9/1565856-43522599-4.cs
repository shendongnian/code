    [Authorize]
    [HttpGet]
    public ActionResult GetSelectedClientID()
    {
       var selectedClientId = HelperMethods.GetClientId().ToString();
       return Content(selectedClientId);
    }
