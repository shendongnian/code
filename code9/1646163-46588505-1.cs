    public MyConstructor()
    {
        SetAsyncPropertyA();
    }
    private async void SetAsyncPropertyA()
    {
        try
        {
            this.AsyncPropertyA = await GetAsyncProperty().ConfigureAwait(false);
        }
        catch (Exception e)
        {
            // log the error or show a message
        }
    }
