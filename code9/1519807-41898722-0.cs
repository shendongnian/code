    public ActionResult DoSomething() {
      var customer = new Customer();
      var validator = new CustomerValidator();
      var results = validator.Validate(customer);
     results.AddToModelState(ModelState, null);
     return View();
    }
