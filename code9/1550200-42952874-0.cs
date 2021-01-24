    public ActionResult MailViewer(string data)
            {
                var result = System.Web.Helpers.Json.Decode<Mail>(data);
                
                return View();
    
            }
