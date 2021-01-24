    public ActionResult ReportaProblem(string title, string description, string url)
    {
    tblReportProblem feature = new tblReportProblem();
    var path = "";
    feature.Title = title;
    feature.Description = description;
    feature.DateTime = DateTime.UtcNow;
    feature.UserId = AppConfig.LoginId;
    HttpPostedFile fu = null;
    if (Request.Files.Count > 0 )
        {
           //get the posted file
           fu = Request.Files[0];
           //apply logic to posted file
           if(fu!=null) {
               string newName = "";
               var filename = "";
               filename = Path.GetFileName(fu.FileName).ToLower();
               newName = DateTime.Now.ToString("MMddyyHHmmss") + filename;
               path = Path.Combine(Server.MapPath(Constants.Paths.ProblemImagePath + newName));
               fu.SaveAs(path);
               feature.FileName = newName;
           }
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
