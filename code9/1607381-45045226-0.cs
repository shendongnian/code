    [HttpPost]
    public ActionResult Edit(SettingModel model)
    {
       if (ModelState.IsValid)
       {
           ...
          return RedirectToAction("List")
              .WithSuccess($"Setting was updated successfully.");
       }
       return View(model);
    }
