    public class SessionContextConfiguration : DbConfiguration
    {
        public SessionContextConfiguration()
        {
            AddInterceptor(new SessionContextDbConnectionInterceptor());
            AddInterceptor(new SessionContextDbCommandInterceptor());
        }
    }
