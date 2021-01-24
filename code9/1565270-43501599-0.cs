    public void Update(params T[] entities)
    {
        using (var context = new BorselDBEntities())
        {
            foreach (T entity in entities)
            {
                var myEntity = context.Entry(entity);
                myEntity.State = EntityState.Modified;
            }   
            context.SaveChanges();
        }
    }
