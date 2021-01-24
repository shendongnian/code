    public interface ISessionFactoryBuilder
    {
        IDictionary<string, ISessionFactory> SessionFactories { get; }
    }
    public IDictionary<string, ISessionFactory> SessionFactories { get; private set; }
        private readonly IConfigurationManager _configurationManager;
        
        public SessionFactoryBuilder(IConfigurationManager configurationManager)
        {
            this._configurationManager = configurationManager;
            this.SessionFactories = this.BuildSessionFactories();
        }
        private IDictionary<string, ISessionFactory> BuildSessionFactories()
        {
            var sessionFactories = new Dictionary<string, ISessionFactory>(StringComparer.InvariantCultureIgnoreCase);
            var connectionStrings = this._configurationManager.GetConnectionStrings();
            if (connectionStrings.Count == 0)
                throw new ConfigurationErrorsException("No connection descriptions can be found!");
            foreach (ConnectionStringSettings item in connectionStrings)
                if (item.Name != "LocalSqlServer" && item.Name != "OraAspNetConString")
                    sessionFactories.Add(item.Name, this.InitializeSessionFactory(item.ConnectionString, item.ProviderName));
            return sessionFactories;
        }
        private class Connectiontypes
        {
            public string Db_type { get; set; }
            public FluentConfiguration Configuration { get; set; }
        }
        private ISessionFactory InitializeSessionFactory(string connectionString = "", string providerName = "")
        {
            Trace.WriteLine($"{connectionString}");
            List<SessionFactoryBuilder.Connectiontypes> conntypes = new List<SessionFactoryBuilder.Connectiontypes> {
                new SessionFactoryBuilder.Connectiontypes
                {
                    Db_type = "System.Data.SqlClient",
                    Configuration = Fluently.Configure().Database(MsSqlConfiguration.MsSql2005.ConnectionString(connectionString).ShowSql() //TODO 20160928 _connectionString!!!
                        .Dialect<XMsSql2005Dialect>()) },
                new SessionFactoryBuilder.Connectiontypes
                {
                    Db_type = "System.Data.OracleDataClient",
                    Configuration = Fluently.Configure().Database(OracleDataClientConfiguration.Oracle10
                        .ConnectionString(connectionString).Provider<NHibernate.Connection.DriverConnectionProvider>()
                        //64bit-re váltás után ez kommentálva kett .Driver<NHibernate.Driver.OracleDataClientDriver>()
                        .Driver<NHibernate.Driver.OracleManagedDataClientDriver>()
                        .Dialect<XOracle10gDialect>().ShowSql())
                },
                new SessionFactoryBuilder.Connectiontypes
                {
                    Db_type = "System.Data.MySQLDataClient", Configuration = Fluently.Configure()
                        .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                }
            };
            FluentConfiguration fluentConfiguration = conntypes.Find(x => x.Db_type == providerName).Configuration;
            fluentConfiguration.ExposeConfiguration(x =>
            {
                x.SetProperty("command_timeout", "120");
            });
    #if DEBUG
            fluentConfiguration.ExposeConfiguration(x =>
            {
                x.SetInterceptor(new SqlStatementInterceptor());
            });
    #endif
            var mappings = fluentConfiguration.Mappings(m =>
            {
                m.FluentMappings.AddFromAssemblyOf<UsersMap>();
            });
            var config = mappings.BuildConfiguration();
            foreach (PersistentClass persistentClass in config.ClassMappings)
            {
                persistentClass.DynamicUpdate = true;
            }
            var sessionFactory = mappings
    #if DEBUG
                .Diagnostics(d => d.Enable(true))
                .Diagnostics(d => d.OutputToConsole())
    #endif
                .BuildSessionFactory();
            return sessionFactory;
        }
		
        public void Dispose()
        {
            if (this.SessionFactories.Count > 0)
            {
                foreach (var item in this.SessionFactories)
                {
                    item.Value.Close();
                    item.Value.Dispose();
                }
                this.SessionFactories = null;
            }
        }
	}
