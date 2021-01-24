    public ActionResult Edit(TrainerModel model)
    {
        ModelState[nameof(model.Email)]?.Errors?.Clear();
        ModelState[nameof(model.Password)]?.Errors?.Clear();
        if (ModelState.IsValid)
        {
            //
        }
        return View(model);
     }
