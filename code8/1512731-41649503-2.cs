        [HttpPost]
       public JsonResult CreateBug(string Id, string Date, string IsFixed ,   string Scenario)
     {
        var bugId = GetBugId(jsonRequest);
       return this.Json(bugId, JsonRequestBehavior.AllowGet);
    }
