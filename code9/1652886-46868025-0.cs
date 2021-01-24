    [HttpPost]
    public ActionResult Index(PersonnelModel  model)
    {
      if (ModelState.IsValid)
      {
          return Json(new {status = "success", message= "Thanks for the details"});
      }
      else
      {
         var errors = new List<string>();
         foreach (var modelStateVal in ViewData.ModelState.Values)
         {
            errors.AddRange(modelStateVal.Errors.Select(error => error.ErrorMessage));
         }
         return Json(new {status = "validationerror", errors = errors});
      }
    }
