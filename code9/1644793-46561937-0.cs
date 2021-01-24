	internal static class NHSessionFactory
	{
		static Configuration nhConfiguration;
		static ISessionFactory nhSessionFactory;
		const FlushMode defaultFlushMode = FlushMode.Commit;
		internal static ISessionFactory SessionFactory
		{
			get { return nhSessionFactory; }
		}
		internal static void CreateSessionFactory()
		{
			CreateSessionFactory(null);
		}
		internal static void CreateSessionFactory(string configFilePath)
		{
			CreateSessionFactory(configFilePath, defaultFlushMode);
		}
		internal static void CreateSessionFactory(string configFilePath, FlushMode flushMode = defaultFlushMode)
		{
			if(nhSessionFactory != null)
				throw new InvalidOperationNHFacadeException("SessionFactory is already created.");
			nhConfiguration = new Configuration();
			try
			{
				if(string.IsNullOrEmpty(configFilePath))
					nhConfiguration.Configure();
				else
					nhConfiguration.Configure(configFilePath);
				nhConfiguration.SessionFactory().DefaultFlushMode(flushMode);
			}
			catch(Exception exception)
			{
				throw new NHFacadeException("Failed to configure session factory.", exception);
			}
			try
			{
				nhSessionFactory = nhConfiguration.BuildSessionFactory();
			}
			catch(Exception exception)
			{
				throw new NHFacadeException("Failed to build session factory.", exception);
			}
		}
		internal static void CloseSessionFactory()
		{
			if(nhSessionFactory != null)
			{
				if(nhSessionFactory.IsClosed == false)
					nhSessionFactory.Close();
				nhSessionFactory.Dispose();
				nhSessionFactory = null;
			}
			if(nhConfiguration != null)
				nhConfiguration = null;
		}
	}
