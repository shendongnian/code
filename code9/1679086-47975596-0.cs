    using (StandardKernel _kernal = new StandardKernel())
    {
        _kernal.Load(Assembly.GetExecutingAssembly());
        // do work
        BruceDbContext ctx = _kernal.Get<BruceDbContext>();
        var todoitem = ctx.TodoItems.FirstOrDefault();
        log.Info(JsonConvert.SerializeObject(todoitem));
    }
