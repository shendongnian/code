    public Task SomethingAsync()
    {
         return Task.Run(() => DoWork());
    }
    
    //Same as...
    
    public async Task SomethingAsync()
    {
         await Task.Run(() => DoWork());
    }
    
    //And now in other methods you can....
    
    public async void AnotherMethod()
    {
         await SomethingAsync();
         //Do more work after it's complete.
    }
