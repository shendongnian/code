    [HttpGet]
    //to prevent conflict with HttpGet use inline namespacing
    public System.Web.Mvc.JsonResult GetTimes()
    {
        return new System.Web.Mvc.JsonResult { Data = result };
    }
