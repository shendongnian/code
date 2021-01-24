    public ActionResult Method()
     {
      if( Session["UserType"] = 3)
       {
         return View([forbidden page URL here]);
       }
      else
       {
         return View("controller/view");
       } 
     }
