    public ActionResult shows()
        {
            //one department can have many employees and one employee can only be parrt of one department
            // below LINQ query fetches the count of employees belonging to each department
            var x = _context.Employees.Include("Department").GroupBy(e => new { e.DepartmentId, e.Department.Name})
         .Select(y=> new MyViewModel{
                 Department= y.Key.Name
                count = y.Count()               
            }).ToList();
         // code removed for brevity
            return Content("x");
        }
