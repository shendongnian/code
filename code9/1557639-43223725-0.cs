    public ActionResult Method()
     {
      if( Session["UserType"] = 3)
       {
         return RedirectToAction([forbidden page URL here]);
       }
      else
       {
         return RedirectToAction("controller/view");
       } 
     }
