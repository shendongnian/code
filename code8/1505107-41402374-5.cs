     public ActionResult Quotes(Home model)
     {
         if (!ModelState.IsValid)
         {
            List<string> errors = new List<string>();
            foreach (var modelStateVal in ViewData.ModelState.Values)
            {
                foreach (var error in modelStateVal.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            TempData["errors"] = errors;
            return RedirectToAction("Index");
          }
            //continue your code to save
                   
     }
