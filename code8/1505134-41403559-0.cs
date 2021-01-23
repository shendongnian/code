    using (var context = new MyContext())
    {
      context.MyEntities.AddObject(newEmployee);
      context.SaveChanges();
    
      int id = newEmployee.Id; // Your Identity column ID
      newEmployee.streEmpId = "EMP" + id;
      context.Entry(newEmployee).State = EntityState.Modified;
      context.SaveChanges();
      
    }
