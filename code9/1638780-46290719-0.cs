    using (SchoolDBContext newCtx = new SchoolDBContext())
    {
        newCtx.Students.Attach(stud);
        newCtx.ObjectStateManager.ChangeObjectState(stud, System.Data.EntityState.Modified);        
        newCtx.SaveChanges();
    }
