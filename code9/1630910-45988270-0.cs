        else
        {                
            T tmp = view.ToPersistent(dbContext);
            //Could also do "dbCondext.Set<T>().Attach(tmp);"  but I split it for this example
            DbSet<T> t = dbCondext.Set<T>();
            t.Attach(tmp);
            dbContext.Entry(tmp).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return tmp.ID;
        }
