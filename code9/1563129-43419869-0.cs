    class AccountService : IAccountService 
    {
        public AccountService(ILoggingServiceFactory factory) 
        {
            _log = factory.GetService(this.GetType());
        }
    }
