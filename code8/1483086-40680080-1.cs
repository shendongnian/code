    [HttpPost]
    [Route("log/heat/request")]
    public ActionResult RequestPOHeat(string Quantity, string RequestDate, string CampaignDetail, string Notes)
    {
       var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files(0) : null;
       if (file != null && file.ContentLength > 0) {
          //If file is posted you will get here..
       }
     ......
    }
