    // Read the entity
    MyEntity entity;
    using (var context = new MyContext())
    {
        entity = context.MyEntities.Single(e => e.Id == id1);
    }
    // Read and update the entity
    using (var context = new MyContext())
    {
        var entity2 = context.MyEntities.Single(e => e.Id == id1);
        entity2.Counter++;
        context.SaveChanges();
    }
    // Try to update stale data
    // - an OptimisticConcurrencyException will be thrown
    using (var context = new MyContext())
    {
        entity.Counter++;
        context.SaveChanges();
    }
