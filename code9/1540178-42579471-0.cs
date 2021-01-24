    [HttpPost]
    public ActionResult SaveDetails([FromBody]PropertyDetailsViewModel PropertyDetail)
    {
        if(PropertyDetail != null)
        {
           return Json("Success");
        }
        return Json("Failed");
    }
