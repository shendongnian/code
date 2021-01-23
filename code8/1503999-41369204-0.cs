            public int Delete<TEntity>(long id) where TEntity : BaseModel
            {
               using (var context = GetContext())
               {
                  var dbEntity = context.Set<TEntity>().Find(id);
                  dbEntity.IsActive = false;
                  return context.SaveChanges();
               }
            }
