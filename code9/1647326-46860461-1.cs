    [HttpPost]
    [ValidateAntiForgeryToken]
    public JsonResult _CreateCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            // Get the new ID
            int id = category.ID;
            return Json(new { success = true, id = id });
        }
        // Get the validation errors
        var errors = ModelState.Keys.Where(k => ModelState[k].Errors.Count > 0).Select(k => new { propertyName = k, errorMessage = ModelState[k].Errors[0].ErrorMessage });
        return Json(new { success = false, errors = errors });
    });
