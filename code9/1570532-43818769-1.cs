    public class TestContext : FooContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public TestContext() { }
        public TestContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
