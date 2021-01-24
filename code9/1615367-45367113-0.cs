     //Insert new Employee
     public IHttpActionResult CreateNewEmployee(EmployeeModels emp)
     {
        using (var ctx = new Employee())
        {
            ctx.tempemp.Add(new tempemp()
            {
                Id = emp.Id,
                name = emp.name,
                mobile = emp.mobile,
                erole = emp.erole,
                dept = emp.dept,
                email = emp.email
            });
            ctx.SaveChanges();
        }
        return Ok();
    }
