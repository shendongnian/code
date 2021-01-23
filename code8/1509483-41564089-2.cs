    using (IDocumentSession session = store.OpenSession())
    {
        session.Store(new Person { Id = 1, Name = "A", Surname = "A" });
        session.Store(new Car { Id = 1, Name = "A", PersonId = 1 });
        session.Store(new Car { Id = 2, Name = "B", PersonId = 1 });
        session.Store(new Car { Id = 3, Name = "C", PersonId = 2 });
        session.SaveChanges();
    }
    
    WaitForIndexing(store); // from RavenTestBase
    
    using (IDocumentSession session = store.OpenSession())
    {
        var resultsForId1 = session
            .Query<CarView, CarIndex>()
            .ProjectFromIndexFieldsInto<CarView>()
            .Where(x => x.PersonId == 1);
        Assert.Equal(2, resultsForId1.Count());
        var resultsForId2 = session
            .Query<CarView, CarIndex>()
            .ProjectFromIndexFieldsInto<CarView>()
            .Where(x => x.PersonId == 2);
        Assert.Equal(1, resultsForId2.Count());
    }
