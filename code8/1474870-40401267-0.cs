    using (Entities Context = new Entities())   
    {   
        DepartmentMaster deptDelete = new DepartmentMaster { DepartmentId = 6 };   
        Context.Entry(deptDelete).State = EntityState.Deleted;   
        Context.SaveChanges();   
    }
