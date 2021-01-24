    public void Test()
    {
      AsyncContext.Run(async () =>
      {
        ContextUtils.DbContext = new SomeDbContext();
        using (ContextUtils.DbContext)
        {
          await DoSomeActions();
        }
      });
    }
