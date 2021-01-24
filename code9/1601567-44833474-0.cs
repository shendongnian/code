    public class MyContext : DbContext
    {
        public MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }
    }
