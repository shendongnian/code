    public ActionResult PopulateInProgressTable()
    {
       var results = _api.Tier2.Issues.GetTier2Issue;
       // read into object array 
       var result = from r in results
                    select new object[]
                    {
                         r.Id,
                         r.Title
                    }; 
        // Get the sEcho param  
        var _sEcho = request.QueryString["sEcho"];
        // return data to datatable
        return Json(new
        {
            _sEcho,
            iTotalRecords = result.Count(),
            iTotalDisplayRecords = result.Count(),
            aaData = result
        }, JsonRequestBehavior.AllowGet);
    }
