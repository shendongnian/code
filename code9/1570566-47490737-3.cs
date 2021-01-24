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
        private LoggerProviderConfiguration loggerProviderConfiguration;
        private Action<string> verbose;
        internal StatefullLoggerProvider() {}
        internal void Set(Action<string> verbose, LoggerProviderConfiguration loggerProviderConfiguration)
        {
            this.verbose = verbose;
            this.loggerProviderConfiguration = loggerProviderConfiguration;
        }
        public ILogger CreateLogger(string categoryName) =>
            new Logger(categoryName, verbose, loggerProviderConfiguration);
        void IDisposable.Dispose(){}
    }
    public class MyDbContext : DbContext
    {
        public MyDbContext(Action<DbContextOptionsBuilder<MyDbContext>> 
           buildOptionsBuilder)
            : base(CreateOptions(buildOptionsBuilder))
        {
        }
          private static DbContextOptions<MyDbContext> CreateOptions(
            Action<DbContextOptionsBuilder<MyDbContext>> buildOptionsBuilder
            )
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            buildOptionsBuilder(optionsBuilder);
            var options = optionsBuilder.Options;
            return options;
        }
    }
        private static Action<DbContextOptionsBuilder<MyDbContext>> BuildOptionsBuilder(string connectionString, bool inMemory, Action<string> verbose=null)
        {
            return (optionsBuilder) =>
            {
                if (verbose != null)
                {
                    var loggerFactory = StatefullLoggerFactoryPool.Instance.Get(verbose, new LoggerProviderConfiguration() { Enabled = true, CommandBuilderOnly=false });
                    optionsBuilder.UseLoggerFactory(loggerFactory);
                }
                if (inMemory)
                    optionsBuilder.UseInMemoryDatabase(
                      "EfCoreTest_InMemory"
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
        readonly Action<string> verbose;
        readonly LoggerProviderConfiguration loggerProviderConfiguration;
        public Logger(string categoryName, Action<string> verbose, LoggerProviderConfiguration loggerProviderConfiguration)
        {
            this.categoryName = categoryName;
            this.verbose = verbose;
            this.loggerProviderConfiguration = loggerProviderConfiguration;
        }
        public IDisposable BeginScope<TState>(TState state) =>
            null;
        public bool IsEnabled(LogLevel logLevel) =>
            verbose != null;
        static readonly List<string> events = new List<string> { "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionClosing",
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionClosed",
                "Microsoft.EntityFrameworkCore.Database.Command.DataReaderDisposing",
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionOpened",
                "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionOpening",
                "Microsoft.EntityFrameworkCore.Infrastructure.ServiceProviderCreated",
                "Microsoft.EntityFrameworkCore.Infrastructure.ContextInitialized"
            };
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (verbose != null)
            {
                if (!loggerProviderConfiguration.CommandBuilderOnly ||
                    (loggerProviderConfiguration.CommandBuilderOnly && events.Contains(eventId.Name) ))
                {
                    var text = formatter(state, exception);
                    verbose($"MESSAGE; categoryName={categoryName} eventId={eventId} logLevel={logLevel}" + Environment.NewLine + text);
                }
            }
        }
    }
