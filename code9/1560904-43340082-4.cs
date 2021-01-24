     public ActionResult Index(HttpPostedFileBase file)
     {
        string Message = string.Empty;
        if (file != null && file.ContentLength > 0)
        try
           {
               string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));
               file.SaveAs(path);
               Message = "Success";
           }
           catch (Exception ex)
           {
                Message = "Error:" + ex.Message.ToString();
           }
           
           //Adding File in TempData.
           TempData["FileData"] = file;
           return RedirectToAction("NewControllerAction", "NewController", new { strMessage = Message });
     }
