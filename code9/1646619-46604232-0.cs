    static Dictionary<Guid, int> Progress = new Dictionary<Guid, double>();
    [HttpPost]
    public ActionResult SendEmail(SendEmailCriteria searchParams)
    {
         var guid = Guid.NewGuid();
         Task.Factory.StartNew(() => {
             foreach(var email in emails)
             {
                 var index = emails.IndexOf(email) + 1;
                 if(index / 100 == 0)
                    Progress[guid] = index * 100 / emails.Count;
                 Send(email);         
             }
         });
         return Json(new {guid});
    }
    [HttpGet]
    public ActionResult Status(Guid guid)
    {
         return Json(new {progress = Progress[guid]});
    }
