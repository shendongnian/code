    using(ISession.BeginTransaction())
    {
        ISession.Save(instance);
        ISession.Transaction.Commit();
        ISession.Refresh(instance);
        return instance;
    }
