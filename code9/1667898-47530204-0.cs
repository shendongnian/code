    public ActionResult SampleResult(Survey surveyModel)
    {
    Model model = new Survey();;
    .
    . Do something with model here
    .
    if (model.Id != 0)
    {
         
         return PartialView("MyView", model);
    }
      return View(surveyModel);  
    }
