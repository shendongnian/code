    [HttpPost]
    public ActionResult UploadFile()
    {
        List<string> errors = new List<string>(); // added this just to return something
    
        if(Request.Files.Count > 0)
        {
            HttpPostedFileBase file = Request.Files[0];
            // do something
        }
        else
        {
            // do something
        }
     
        return Json(errors, JsonRequestBehavior.AllowGet);   
    }
