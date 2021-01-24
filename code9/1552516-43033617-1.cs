    public ActionResult Edit(TrainerModel model)
    {
        ModelState["Email"]?.Errors?.Clear();
        ModelState["Password"]?.Errors?.Clear();
        if (ModelState.IsValid)
        {
            //
        }
        return View(model);
     }
