    var emp = new Employee { Name="Scott" };
    db.Employees.Add(emp);
    db.SaveChanges();    
   
    if (String.IsNullOrEmpty(emp.strEmpID))
    {
        e.strEmpID = "EMP" + e.Id;
        db.Entry(e).State=EntityState.Modified;
        db.SaveChanges();
    }
