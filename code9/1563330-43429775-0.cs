    [HttpPost]
    public ActionResult Edit(EditModel model)
    {
        if (string.IsNullOrEmpty(model.ISBN) && string.IsNullOrEmpty(model.ISBN13))
        {
            var validationMessage = "Please provide ISBN or ISBN13.";
            this.ModelState.AddModelError("ISBN", validationMessage);
            this.ModelState.AddModelError("ISBN13", validationMessage);
        }
    
        if (!string.IsNullOrEmpty(model.ISBN) && !string.IsNullOrEmpty(model.ISBN13))
        {
            var validationMessage = "Please provide either the ISBN or the ISBN13.";
            this.ModelState.AddModelError("ISBN", validationMessage);
            this.ModelState.AddModelError("ISBN13", validationMessage);
        }
    
        if (this.ModelState.IsValid)
        {
            // do something with the model
        }
        return this.View(model);
    }
