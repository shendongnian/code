    public class StatefullLoggerFactoryPool
    {
        public static readonly StatefullLoggerFactoryPool Instance = new StatefullLoggerFactoryPool(()=> new StatefullLoggerFactory());
        private readonly Func<StatefullLoggerFactory> construct;
        private readonly ConcurrentBag<StatefullLoggerFactory> bag = new ConcurrentBag<StatefullLoggerFactory>();
        private StatefullLoggerFactoryPool(Func<StatefullLoggerFactory> construct) =>
            this.construct = construct;
        public StatefullLoggerFactory Get(Action<string> verbose, LoggerProviderConfiguration loggerProviderConfiguration)
        {
            if (!bag.TryTake(out StatefullLoggerFactory statefullLoggerFactory))
                statefullLoggerFactory = construct();
            statefullLoggerFactory.LoggerProvider.Set(verbose, loggerProviderConfiguration);
            return statefullLoggerFactory;
        }
        public void Return(StatefullLoggerFactory statefullLoggerFactory)
        {
            statefullLoggerFactory.LoggerProvider.Set(null, null);
            bag.Add(statefullLoggerFactory);
        }
    }
     public class StatefullLoggerFactory : LoggerFactory
    {
        public readonly StatefullLoggerProvider LoggerProvider;
        internal StatefullLoggerFactory() : this(new StatefullLoggerProvider()){}
        private StatefullLoggerFactory(StatefullLoggerProvider loggerProvider) : base(new[] { loggerProvider }) =>
            LoggerProvider = loggerProvider;
    }
    public class StatefullLoggerProvider : ILoggerProvider
    {
        internal LoggerProviderConfiguration loggerProviderConfiguration;
        internal Action<string> verbose;
        internal StatefullLoggerProvider() {}
        internal void Set(Action<string> verbose, LoggerProviderConfiguration loggerProviderConfiguration)
        {
            this.verbose = verbose;
            this.loggerProviderConfiguration = loggerProviderConfiguration;
        }
        public ILogger CreateLogger(string categoryName) =>
            new Logger(categoryName, this);
        void IDisposable.Dispose(){}
    }
    public class MyDbContext : DbContext
    {
        readonly Action<DbContextOptionsBuilder> buildOptionsBuilder;
        readonly Action<string> verbose;
        public MyDbContext(Action<DbContextOptionsBuilder> buildOptionsBuilder, Action<string> verbose=null): base()
        {
            this.buildOptionsBuilder = buildOptionsBuilder;
            this.verbose = verbose;
        }
         private Action returnLoggerFactory;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (verbose != null)
            {
                var loggerFactory = StatefullLoggerFactoryPool.Instance.Get(verbose, new LoggerProviderConfiguration { Enabled = true, CommandBuilderOnly = false });
                returnLoggerFactory = () => StatefullLoggerFactoryPool.Instance.Return(loggerFactory);
                optionsBuilder.UseLoggerFactory(loggerFactory);
            }
            buildOptionsBuilder(optionsBuilder);
        }
        // NOTE: not threadsafe way of disposing
        public override void Dispose()
        {
            returnLoggerFactory?.Invoke();
            returnLoggerFactory = null;
            base.Dispose();
        }
    }
        private static Action<DbContextOptionsBuilder> BuildOptionsBuilder(string connectionString, bool inMemory)
        {
            return (optionsBuilder) =>
            {
                if (inMemory)
                    optionsBuilder.UseInMemoryDatabase(
                      "EfCore_NETFramework_Sandbox"
                    );
                else
                    //Assembly.GetAssembly(typeof(Program))
                    optionsBuilder.UseSqlServer(
                            connectionString,
                            sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.MigrationsAssembly("EfCore.NETFramework.Sandbox")
                            );
            };
        }
    class Logger : ILogger
    {
        readonly string categoryName;
        readonly StatefullLoggerProvider statefullLoggerProvider;
        public Logger(string categoryName, StatefullLoggerProvider statefullLoggerProvider)
        {
            this.categoryName = categoryName;
            this.statefullLoggerProvider = statefullLoggerProvider;
        }
        public IDisposable BeginScope<TState>(TState state) =>
            null;
        public bool IsEnabled(LogLevel logLevel) =>
            statefullLoggerProvider?.verbose != null;
        static readonly List<string> events = new List<string> {
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionClosing",
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionClosed",
                "Microsoft.EntityFrameworkCore.Database.Command.DataReaderDisposing",
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionOpened",
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionOpening",
                "Microsoft.EntityFrameworkCore.Infrastructure.ServiceProviderCreated",
                "Microsoft.EntityFrameworkCore.Infrastructure.ContextInitialized"
            };
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (statefullLoggerProvider?.verbose != null)
            {
                if (!statefullLoggerProvider.loggerProviderConfiguration.CommandBuilderOnly ||
                    (statefullLoggerProvider.loggerProviderConfiguration.CommandBuilderOnly && events.Contains(eventId.Name) ))
                {
                    var text = formatter(state, exception);
                    statefullLoggerProvider.verbose($"MESSAGE; categoryName={categoryName} eventId={eventId} logLevel={logLevel}" + Environment.NewLine + text);
                }
            }
        }
    }
