    using (ITransaction transaction = Session.BeginTransaction())
    {
        var persisted = Session.Get<SomeType>(object.Id); //object will be loaded if not already in the session
        Session.Delete(persisted);
        transaction.Commit();
    }
