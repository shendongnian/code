    public abstract class DataSeed 
    {
        protected const String DRIVE = "http://mydriveurl";
        protected readonly Context _context;
        protected readonly ReadOnlyCollection<string> _languages = 
                                         (new List<string> { "en", "fr" }).AsReadOnly();
        protected DataSeed()
        {
            _context = someValue;
        }
    }
    public MyDataSeed : DataSeed 
    {
        public MyDataSeed()
            : base()
        {
            // Other constructor-y stuff
        }
    }
