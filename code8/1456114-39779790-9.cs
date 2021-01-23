    [HttpPost]
    public ActionResult CreateComment(CommentToBookVm model) 
    {
      if (ModelState.IsValid) 
      {
        //your existing code to save data to the table
         return RedirectToAction("Details","Book", new { id=model.BookId} );
         
      }
      
      // Hoping that the below code might not execute as client side validation
     //  must have prevented the form submission if there was a validation error.
      return View(model);
    }
