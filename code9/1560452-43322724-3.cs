    public class SomeClass
    {
        private readonly IApplicationUserAccessor _userAccessor;
        public SomeClass(IApplicationUserAccessor userAccessor)
        {
            _userAcccessor = userAccessor;
        }
    
        public async Task DoSomethingWithUser() {
            var user = await _userAccessor.GetUser();
            // do stuff
        }
    }
