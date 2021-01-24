    just add second constructor			
    private readonly DbContext dbContext;
    public GenericRepository(context1 ctx)
    {dbContext=ctx}
    public GenericRepository(context2 ctx, bool fakeParamToAddSecondConstructor) 
    {dbContext=ctx}
