    public async Task<Response> Method1(parameter ...)
    {
        try
        {
            //some insert/update operation to DB
            return <instance of Response>;
        }
        catch (MongoServerException mse)
        ...
