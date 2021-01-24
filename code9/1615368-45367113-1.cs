    [HttpGet]
    public JsonResult GetEmployeeDetails(int EmployeeId)
    {
        //here, DatabaseContext.Employees is your DBContext and Employees table.
        var model = DatabaseContext.Employees.SingleOrDefault(x=>x.Id == EmployeeId);
        return Json(model);
    }
