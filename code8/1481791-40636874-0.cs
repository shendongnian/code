    [HttpPost]
    public ActionResult SomePostAction(SomeViewModel vm)
    {
       if(ModelState.IsValid) // Is User Input Valid?
       {
           try
           {
               CommitData();
               TempData["UserMessage"] = new { CssClassName = "alert-sucess", Title = "Success!", Message = "Operation Done." };
               return RedirectToAction("Success");
           }
           catch(Exception e)
           {
               TempData["UserMessage"] =  new { CssClassName = "alert-error", Title = "Error!", Message = "Operation Failed." };
               return RedirectToAction("Error");
           }
    
       }
    
       return View(vm); // Return View Model with model state errors
    }
