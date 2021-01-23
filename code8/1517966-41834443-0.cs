    public class LoginService : ILoginService
    {
        public IConnectionMultiplexer redis,
        public ISerialiserFactory serialiser,
        public IDataService dataService,
        public ILookupNormalizer normaliser,
        public IPasswordHasher hasher
        public LoginService(/* inject your services here */) 
        {
            
        }
        public async Task<bool> Login(LoginModel login) 
        {
            // Do your logic here and perform the login
            return /*true or false*/;
        }
    }
