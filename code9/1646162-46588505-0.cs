    public MyConstructor()
    {
        try
        {
            Task task = SetAsyncPropertyA();
        }
        catch (Exception e)
        {
            // log the error or show a message
        }
    }
    private async Task SetAsyncPropertyA()
    {
        this.AsyncPropertyA = await GetAsyncProperty().ConfigureAwait(false);
    }
