    IAmazonDynamoDB client;
    public ValuesController(IAmazonDynamoDB dbClient)
    {
        this.client = dbClient;
    }
