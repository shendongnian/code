    if (ModelState.IsValid)
    {
        // Check if employee with the same name already exists
        var existingEmployee = db.Employees.FirstOrDefault(e => e.Name == employee.Name);
        // No
        if (existingEmployee == null)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         // Yes
         else
         {
             ViewBag.errorMessage = "Name not available";
             return (ViewBag.errorMessage);
          }           
    }
