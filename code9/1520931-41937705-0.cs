    static SessionManager()
    {
        _instance = new SessionManager();
        _instance.RecoverState();
    }
    static SessionManagerDatabase()
    {
        _instance = new SessionManagerDatabase();
        _instance.Synchronize();
    }
