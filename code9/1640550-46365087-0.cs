    using (var dbCtx = new SchoolDBEntities())
        {
            //Add newStudent entity into DbEntityEntry and mark EntityState to Added
            dbCtx.Entry(newStudent).State = System.Data.Entity.EntityState.Added;
            // call SaveChanges method to save new Student into database
            dbCtx.SaveChanges();
        }
