    static Dictionary<Guid, int> Progress = new Dictionary<Guid, int>();
    [HttpPost]
    public ActionResult SendEmail(SendEmailCriteria searchParams)
    {
         var guid = Guid.NewGuid();
         Task.Factory.StartNew(() => {
             foreach(var email in emails)
             {                 
                 Send(email);         
                 Progress[guid] = (emails.IndexOf(email) + 1) * 100 / emails.Count;
             }
         });
         return Json(new {guid});
    }
    [HttpGet]
    public ActionResult Status(Guid guid)
    {
         return Json(new {progress = Progress[guid]});
    }
