    public class SomeAction : ISomeAction
    {
        public Task<String> SomeTaskAsync()
        {
            return Task.Run( (Func<String>)this.SomeMethod );
        }
    }
