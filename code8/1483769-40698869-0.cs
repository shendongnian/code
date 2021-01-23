    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(int id, ViewModelCapsule model)
    {
        try
        {
    
            if(model.FirstModel != null && model.FirstModel.Menu1 != "ABC")
            {
                ModelState.Clear();
                model.SecondModel = null
    
            }
    
            if (TryValidateModel(model))
            {
                // Here I am expecting the form to validate since the first form has valid date
                // Do somethig with the request
    
            }
    
            return new RedirectAction("Index");
    
        }
        catch (Exception exception)
        {
            return Content(exception.Message);
        }
    }
