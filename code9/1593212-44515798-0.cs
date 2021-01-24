        private static DemoContext _instance;
        public DemoContext() : base("MyDemoConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DemoContext, Configuration>());
        }
        public static DemoContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DemoContext();
                }
                return _instance;
            }
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
