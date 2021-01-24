    [ChildActionOnly]
    public ActionResult MyPartialViewName(string firstName, string lastName)
    {
    // create model here...
     var model = repository.GetThingByParameter(firstName,lastName);
     var partialViewModel = new PartialViewModel(model);
     return PartialView(mypartialViewModel); 
    }
