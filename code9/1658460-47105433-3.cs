    [HttpPost]
    public IActionResult AddBook(Book model,string redirectUrl)
    {
        if (ModelState.IsValid)
        {
            // to do : Save   
            return PartialView("_AddedSuccessfully", redirectUrl);
        }
        return PartialView("_AddBook", model);
    }
