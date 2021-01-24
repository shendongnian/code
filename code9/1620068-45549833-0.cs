    public class BaseContext : DbContext
    {
        public BaseContext()
            : base("ConnectionString")
        {
            Database.SetInitializer<BaseContext>(null);
        }
    }
