    public virtual void Update(T entity)
    {
           var existingEntity = DbContext.Entity.First(x => x.Id == entity.Id);
           autoMapper.Map(entity, existingEntity);
           DbContext.SaveChanges();
    }
