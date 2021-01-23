    // GET: Books/Edit/5       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var compModel = new BookAuthorCompositeModel();
            compModel.book = dbBooks.Books.ToList().Where(a => a.Id == id).SingleOrDefault();
            compModel.author = dbBooks.Authors.ToList().Where(x => x.Id == id).SingleOrDefault();
            
            
            return View(bookEdit);
        }
