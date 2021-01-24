    public ActionResult ReportaProblem(string title, string description, string url)
    {
        tblReportProblem feature = new tblReportProblem();
        var path = "";
        feature.Title = title;
        feature.Description = description;
        feature.DateTime = DateTime.UtcNow;
        feature.UserId = AppConfig.LoginId;
        //fileUploadConrol1 is id of file upload control in your aspx markup
        if(fileUploadConrol1.HasFile)
        {
           //this line below is not needed
          //HttpPostedFileBase fu = Request.Files["fuScreenCapture"];
          //if (fu.FileName != "")
          //{
            string newName = "";
            var filename = "";
            filename = Path.GetFileName(fileUploadControl1.FileName).ToLower();
            newName = DateTime.Now.ToString("MMddyyHHmmss") + filename;
            path = Path.Combine(Server.MapPath(Constants.Paths.ProblemImagePath + newName));
            fileUploadControl1.SaveAs(path);
            feature.FileName = newName;
          //}
        }
        if (_IProject.AddReportProblem(feature))
        {
            TempData["success"] = Constants.ReportProblemSuccess;
        }
        Attachment attachment = null;
        if(path!= string.Empty) 
         {
           attachment = new Attachment(path);
         }
        ReportProblemEmailToAdmin(title, description, url, attachment);
        return RedirectToAction("ReportaProblem");
    }
