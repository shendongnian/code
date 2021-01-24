    [HttpPost]
    [ActionName("Analyze")]
    public ActionResult Analyze(Model viewModel)
    {
        if(viewModel.PropertyName.IsNullOrEmpty()){
        {
            ModelState.AddModelError("PropertyName", "The Field InputFieldName neeeds to be filled!");
        }
        if (ModelState.IsValid)
        {
            //Do what ever you want with your Inofrmation
            //return a redirct or anything else
        }
        //If you got here some fields are not filled
        return View(viewModel);
    }
