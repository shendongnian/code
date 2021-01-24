    [Post]
    public ActionResult Submit(MyFormViewModel viewModel){
    if (ModelState.IsValid)
            {
    //Do what ever
                return View("Completed");
            }
            else
            {            
    //error do something
                 return View();
            }
    }
