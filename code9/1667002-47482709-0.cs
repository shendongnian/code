    public ViewResult Index() {    
       var userFlag = context.Users.Where(u => u.Flag = true).FirstOrDefault();
       ViewBag.UserFlag = userFlag == null ? true : false;
       return View();    
    }
