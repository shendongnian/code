    public class SessionFactory : IDisposable
	{
		private static ISessionFactory _sessionFactory;
		private static NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();		
		static readonly object factorylock = new object();
		IUserManagement um; 
		public SessionFactory(IUserManagement ium)
		{
			um = ium;
		}
		private static void InitializeSessionFactory(IUserManagement um, bool genereteDB = false)
		{
            _sessionFactory = Fluently.Configure()
					.Database(MsSqlConfiguration.MsSql2008
					.ConnectionString(c => c.FromAppSetting("FluentNHibernateConnection"))
					.ShowSql())
					.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
													.Conventions.AddFromAssemblyOf<SessionFactory>()
							)
					   .ExposeConfiguration(config => SetupEnvers(config, um))					   
					   .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
					.BuildSessionFactory();
        }
        private static void SetupEnvers(NHibernate.Cfg.Configuration cfg, IUserManagement um)
		{
			try
			{
				var enversConf = new NHibernate.Envers.Configuration.Fluent.FluentConfiguration();
                IRevisionListener revListner = new EnversRevisionListener(um);
				enversConf.SetRevisionEntity<RevisionEntity>(e => e.Id, e => e.RevisionDate, revListner);
             }
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
		internal ISession OpenSession()
		{
			lock (factorylock)
			{
				if (_sessionFactory == null)
				{
					InitializeSessionFactory(um);
				}
			}
			NHibernate.ISession session = _sessionFactory.OpenSession();
			return session;
		}
    }
