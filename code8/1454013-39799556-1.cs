    using (var ctx = new DbCtx())
    {
        ctx.Configuration.LazyLoadingEnabled = false;
        ctx.Configuration.ProxyCreationEnabled = false;
        ctx.Configuration.AutoDetectChangesEnabled = false;
        ctx.Database.Log += Console.WriteLine;
        var foo = new Foo {Id = 1, Bars = new List<Bar>()};
        var bar = new Bar { Id = 3, Foos = new List<Foo>() };
        ctx.Entry(foo).State = EntityState.Unchanged;
        ctx.Entry(bar).State = EntityState.Unchanged;
        // create
        ChangeRelationship(ctx, foo, bar, x => x.Bars, EntityState.Added);
        ctx.SaveChanges();
        // remove
        ChangeRelationship(ctx, foo, bar, x => x.Bars, EntityState.Deleted);
        ctx.SaveChanges();
    }
