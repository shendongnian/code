    [HttpPost]
     public ActionResult TempEmp(string name)
    {
                    
                    TempData["EmpName"] = name;
                    return RedirectToAction("PermanentEmp");
    }
    
     //Controller Action 2(PermanentEmployee)
     public ActionResult PermanentEmp()
    {
                   string empName = TempData["EmpName"] as string;
                   return View(empName);
     }
