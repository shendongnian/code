    public void MySyncMethod()
        {
            try
            {
                this.MyAsyncMethod().Wait();
                
            }
            catch (Exception exception)
            {
                //omited
            }
        }
    private async Task MyAsyncMethod()
    {
         await AsyncLogic().ConfigureAwait(false);
    }
