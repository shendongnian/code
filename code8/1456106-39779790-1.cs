    [HttpPost]
    public ActionResult CreateComment(CommentToBookVm model) 
    {
      if (ModelState.IsValid) 
      {
        //your existing code to save data to the table
        return RedirectToAction("Details","Book", new { id=model.BookId} );
      }
      //Model validation failed. Let's return to same view
      // to do : Reload any properties needed for SELECT element if your view has one  
      return View(model);
    }
