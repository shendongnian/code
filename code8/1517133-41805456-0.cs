    // session1, NHibernate
    var obj1 = new FooModel();
    
    session1.Save(obj1, Guid.NewId());
    session1.Commit();
    // session2, NHibernte
    session2.Merge(obj1);
    session2.Commit();
