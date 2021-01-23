    [HttpPost]
    public ActionResult Details(ListAndCreateVm model)
    {
      if(ModelState.IsValid)
      {
        // to do : Save
        return RedirectToAction("Details,"Book",new { id=model.BookId});
      } 
      //lets reload comments because Http is stateless :)
      model.Comments = GetComments(model.BookId);
      return View(model);
    }
