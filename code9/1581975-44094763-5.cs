    public class FooContext : FooParentContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public FooContext() { }
        public FooContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
