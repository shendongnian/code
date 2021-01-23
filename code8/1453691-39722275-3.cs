    public ActionResult Login()
            {
                
                return View();
            }
    
    
    [HttpPost]
    public ActionResult Login(FormCollection form)
    {
        string role = form["roleSelect"];
        string username = form["txtusrname"];
        string password = form["txtpass"];
        webservice.loginservice a= new webservice.loginservice()
        string xyz = a.getlogintype(role, username, password);
        if(xyz== "true")
        {
          return RedirectToAction("Welcome_ActionMethod", "Welcome_Controller");
              
        }
       else
        {
          ViewBag.Message = "Incorrect Login Credential!!!!";
           return View();
        }  
    }
