    [HttpPost]
    public ActionResult EncryptFile(string uploadedfile)
    {
        HttpPostedFileBase myfile = Request.Files[0];
        if (file.ContentLength > 0) 
        {
            // extract only the fielname
            var fileName = Path.GetFileName(file.FileName);
            // store the file inside ~/App_Data/uploads folder
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"),fileName);
           file.SaveAs(path);
         }
          /*process the file without uploading*/
          return Json(new { status = "success", message = "Encrypted!" });
    }
