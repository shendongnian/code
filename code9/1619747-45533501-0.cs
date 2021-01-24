    public void InsertPerson(Person model)
    {
       using (DbEntities db = new DbEntities())
       {
          db.Entry(model).State = System.Data.Entity.EntityState.Added;
          db.SaveChanges();
       }
    }
