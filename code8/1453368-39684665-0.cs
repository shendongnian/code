     //Create ///Get ID of the table
            public static T Add(CellPhoneProjectEntities dbContext, T entity, long id)
            {
                dbContext.Set<T>().Add(entity);
                dbContext.SaveChanges();
                return entity;
            } 
