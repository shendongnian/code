    public ActionResult getMainData()
    {
      //More code up here....
    
      if (Permissions == "ADMIN") {
         ViewBag.AdminMode = True;
      } else {
         ViewBag.AdminMode = False;
      }
    
      //More code down here....
    }
