    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddBook(Book model)
    {
        if (ModelState.IsValid)
        {
            //Your code to store data     
            return PartialView("_AddedSuccessfully");
        }
        return PartialView("_AddBooks", model);
    }
