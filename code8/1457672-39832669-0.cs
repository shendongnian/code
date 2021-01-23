    public class YourDbContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            return new MyContext(...);
        }
