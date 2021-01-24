    //save modified entity using new Context
    using (var dbCtx = new SchoolDBEntities())
    {
        //3. Mark entity as modified
        dbCtx.Entry(stud).State = System.Data.Entity.EntityState.Modified;     
            
    //4. call SaveChanges
    dbCtx.SaveChanges();
    }
    
