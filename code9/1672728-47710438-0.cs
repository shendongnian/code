    public class UnitOfWorkSampleContextBase : IDisposable
    {
        [ThreadStatic]
        private static UnitOfWorkSampleContextBase _instance;
        public static UnitOfWorkSampleContextBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnitOfWorkSampleContextBase();
                }
                return _instance;
            }
        }
        public SampleDbContext Context { get; private set; }
        private UnitOfWorkSampleContextBase()
        {
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void ResolveContext()
        {
            Context = new SampleDbContext(ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString);
        }
        public void Dispose()
        {
            Context.Dispose();
            Context = null;
        }
    }
