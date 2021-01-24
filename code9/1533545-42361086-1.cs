    [HttpGet] // here ([HttpGet] is default so here you can delete this attribute)
    public ActionResult Insert()
    {
        return View();
    }
    [HttpPost]  // here
    public ActionResult Insert(Employee emp)
    {
        Employee emp1 = new Employee();
        emp1.insert(emp);
        return View();
    }
