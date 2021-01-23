    public class FooBar : IFoo
    {
        public Task DoWorkAsync()
        {
            // Do Some Work
    
            //If you can use .NET 4.6
            return Task.CompletedTask;
            //For older versions, the thing you pass in does not matter, I like to use bool.
            return Task.FromResult(false);
        }
    
        public Task<int> GetValueAsync()
        {
            // Do Some Work
            var result = ...;
    
            return Task.FromResult(result);
        }
    }
