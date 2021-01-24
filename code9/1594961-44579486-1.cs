    [HttpPost]
    public ActionResult AnalyzeData (int objectID)
    {
        List<string> retList = new List<string>();
        AnalyzeViewModel avm = new AnalyzeViewModel();
        try {
            retList = SOME LIST
            avm.fileData = retList.ToArray();
            Response.StatusCode = (int)HttpStatusCode.OK;
            var obj = new
            {
                success = true,
                responseText = "Zones data has been calculated."
            };
            return Json(avm, JsonRequestBehavior.AllowGet);
        }
