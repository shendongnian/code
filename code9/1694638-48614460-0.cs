    [HttpPost]    
    public ActionResult DoView () {
            int id = Int.Parse(HttpContext.Current.Request.Form["id"]); 
            var rec = db.Requests.Find (id);
            IQueryable<Request> records = db.Requests.Where (d => d.ReqID == id);
            return View (records);
     }
