     //Controller Action 1 (TemporaryEmployee)
     public ActionResult TemporaryEmployee()
    {
                    Employee employee = new Employee
                    {
                            EmpID = "121",
                            EmpFirstName = "Imran",
                            EmpLastName = "Ghani"
                    };
                    TempData["Employee"] = employee;
                    return RedirectToAction("PermanentEmployee");
    }
    
     //Controller Action 2(PermanentEmployee)
     public ActionResult PermanentEmployee()
    {
                   Employee employee = TempData["Employee"] as Employee;
                   return View(employee);
     }
