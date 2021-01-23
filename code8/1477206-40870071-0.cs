		private static readonly object _syncRoot = new object();
		private ITransaction _transaction;
		private SessionFactory _nhHelper;
		internal ISession _session;
        public UnitOfWork(SessionFactory sf)
		{
			//Contract.Ensures(_session.IsOpen);
			_nhHelper = sf;
			InizializzaSessione();
		}
        public void InizializzaSessione()
		{
			lock (_syncRoot)
			{
				if (_session == null || _session.IsOpen == false)
				{
					_session = _nhHelper.OpenSession();
				}
			}
        }
