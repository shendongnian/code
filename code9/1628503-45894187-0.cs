         public ActionResult Index(int? resumeId)
                    {               
        
                      var temp = _context.Resumes.Where(f => f.ResumeId == 
                      resumeId).SingleOrDefault();
                      var fileRes = new FileContentResult(temp.Content.ToArray(), 
                      temp.ContentType);
                      Session["Path"]= temp.FileName;
                      Session["Type"]=temp.ContentType
                      return View();
                    }
    and Action of File
    
    public ActionResult GetFile()
            {
                if (Session["Path"] != null)
                {
                    FileStream fileStream = new          
                    FileStream(Session["Path"].ToString(), FileMode.Open, 
                    FileAccess.Read);
                    ViewBag.Type=Session["Type"]
                    return File(fileStream, Session["Type"]);
                }
                return View("NotFound");
            }
