    using (DBContext ctx = new DBContext())
    {     
      
      var department = ctx.tbllistDepartment.Where(c => c.lang_sys_id != "Admin001");   
    
        foreach(var item in department)
    {
          var obj = new tbllistDepartment()
          {
             department_sys_id = item.department_sys_id,
             department = item.department,
             status = item.status,
             client_sys_id = item.client_sys_id,
             lang_sys_id = item.lang_sys_id
          }
          ctx.tbllistDepartment.Add(obj);
    }   
    
      // Insert into the database.
      ctx.SaveChanges();                        
    }
