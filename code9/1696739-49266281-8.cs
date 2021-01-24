    private IDynamoDbContext<AwesomeClass> _awesomeContext;
    public AwesomeDynamoDbService(IDynamoDbContext<AwesomeClass> awesomeContext)
    {
        _awesomeContext= awesomeContext;
    }
