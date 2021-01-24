    public ISession GetCurrentSession
        {
            get
            {
                ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer(ConnectionName + ".SessionKey");
                ISession currentSession = sessionStorageContainer.GetCurrentSession();
                if (currentSession == null)
                {
                    currentSession = GetNewSession();
                    sessionStorageContainer.Store(currentSession);
                }
                return currentSession;
            }
        }
    private ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }
