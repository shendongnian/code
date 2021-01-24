    public class SomeController
    {
        DbAuthorizationOptions authOptions;
        public SomeController(IServiceProvider provider)
        {
            authOptions = provider.GetSerivce<DbAuthorizationOptions>();
        }
    }
