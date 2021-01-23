    using(ISession.BeginTransaction())
    {
        ISession.Save(instance);
        ISession.Transaction.Commit();
        
        return instance;
    }
