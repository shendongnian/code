    // GET: Books/Edit/5       
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return HttpNotFound();
        }
        Book bookEdit = dbBooks.Books.Where(a => a.Id == id).Single();
        // UPDATED
        var list = dbBooks.Books.Select(x => new  { ID = x.Id, AuthorName = x.AuthorName });
        ViewBag.Authors = new SelectList(list, "Id", "AuthorName");
        // UPDATED
        return View(bookEdit);
    }
