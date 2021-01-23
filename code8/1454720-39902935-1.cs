    public class UserRepository<TbContext>
    {
        private DbContext Context
        {
            get { return EntityContextFactory<TDbContext>.Current(); }
        }
    }
