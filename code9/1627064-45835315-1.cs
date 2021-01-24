    [HttpPost]  
    public ActionResult UploadFile(HttpPostedFileBase file)  
    {
        string path;
        string msg;
        try
        {
            // file processing logic
            path = _path;
            msg = "File Uploaded Successfully!!";
        }
        catch  
        {  
            msg = "File upload failed!!";
            path = string.Empty;
        }
        var result = new { Path = path, Msg = msg }; // return both image path & upload message
        return Json(result, JsonRequestBehavior.AllowGet);
    }
