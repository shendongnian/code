    public ActionResult Edit(Guid id) { // should not be nullable
        Comment comment = db.Comment.Find(id);
        if (comment == null) {
            return HttpNotFound();
        }
        // Initialize a view model
        CommentVM model = new CommentVM()
        {
            ID = id,
            Title = comment.Title,
            Description = comment.Description,
        }
        return View(model); // return view model
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(CommentVM model) { // BindAttribute not required
        if (!ModelState.IsValid) {
            return View(model);
        }
        // Get the data model
        Comment comment = db.Comment.Where(x => x.Id == model.ID).FirstOrDefault();
        // Update its properties
        comment.Title = model.Title;
        comment.Description = model.Description;
        // Save and redirect
        db.SaveChanges();
        return RedirectToAction("Index");
    }
