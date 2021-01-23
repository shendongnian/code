    public ActionResult Edit([Bind(Include = "Id,ViewName,ViewPath,ViewContent")] View view)
    {
        bool isViewNameInvalid = db.View.Any(v => v.ViewName == view.ViewName && v.Id != view.Id)
        if (isViewNameInvalid)
        {
            ModelState.AddModelError("ViewName", UI_Prototype_MVC_Resources.ErrorViewAlreadyExists);
        }
        bool isViewPathInvalid = db.View.Any(v => v.ViewPath == view.ViewPath && v.Id != view.Id)
        if (isViewPathInvalid)
        {
            ModelState.AddModelError("ViewName", UI_Prototype_MVC_Resources.ErrorPathAlreadyExists);
        }
        if (!ModelState.IsValid)
        {
            return View(view);
        }
        // Save and redirect
        db.Entry(view).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index")
    }
