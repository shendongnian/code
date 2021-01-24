    [HttpPost]
    public ActionResult Employee(EmployeeModel employee)
    {
      if(ModelState.IsValid)
      {
        //Everything is good to process
      }
      return View(employee);//returns view with model error if any
    }
