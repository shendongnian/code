    public class ConcreteStuffFactory
    {
        public ConcreteStuffFactory(IUserContextProvider userContextProvider)
        {
             this._userContextProvider = userContextProvider; 
        }
        private readonly IUserContextProvider _userContextProvider; 
        public IStuffModel CreateStuffModel()
        {
            String userName = this._userContextProvider.UserName; 
            // do things with userName
        }
    }
