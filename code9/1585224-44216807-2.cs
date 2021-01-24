    public class DatabaseRepository : IDatabaseRepository
    {
        public ISession Session { get; set; }
        public DatabaseRepository(ISession session)
        {
            Session = session;
        }
        //other methods here
    }
