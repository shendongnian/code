    [HttpPost]
    [ValidateAntiForgeryToken]
    [ExportModelStateToTempData]
    public ActionResult Update(int id, DetailsPresenter model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var updater = new UpdateAddressServiceProvider(CurrentUser);
                updater.Handle(model.General);
            }
            return new RedirectResult(Url.Action("Show", new { Id = id }) + "#General");
        }
        catch (Exception exception)
        {
            ModelState.AddModelError("error", exception.Message);
            // Return the named view directly, and pass in the model as it stands.
            return View("Show", model);
        }
    }
