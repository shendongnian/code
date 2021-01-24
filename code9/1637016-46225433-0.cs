      public void Save(TEntity entity) //change this to your entity
        {
            if(entity == null)
                return;
            //change this to your key, this is the identifier for new
            if (entity.Id == 0) 
            {
                entity.CreateOnDateTime = DateTime.Now;
                Context.Set<TEntity>().Add(entity);
            }
            
            Context.SaveChanges(); //this may not suit your design
        }
