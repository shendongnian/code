    public ActionResult shows()
    {
        //one department can have many employees and one employee can only be parrt of one department
        // below LINQ query fetches the count of employees belonging to each department
        var x = _context.Employees.Include("Department").GroupBy(e => e.DepartmentId)
     .Select(y=> new MyViewModel{
             Department= y.Key.DepartmentName, // or whatever property you have for storing the name
            count = y.Count()               
        }).ToList();
     // code removed for brevity
        return Content("x");
    }
