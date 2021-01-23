    using (ISession session = Helpers.NHibernateHelper.OpenSession())
    using (ITransaction tran = session.BeginTransaction())
    {
        session.Save(toAdd);
        //foreach (var pi in toAdd.PaymentItems)
        //{
        //    session.Save(pi);
        //}
        tran.Commit();
    }
