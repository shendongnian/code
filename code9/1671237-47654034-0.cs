     [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult doSomething(Something obj)
           {
              //use web service and get string URL
              string urlString = ;// get from the web service response.
    
         if (!string.IsNullOrEmpty(urlString))
         {
             return RedirectToAction(urlString);
         }
    
         //If the urlString is empty Return to a error page
         return View("Error");
    
         
           }
