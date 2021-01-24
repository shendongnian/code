    List<Person> allPeople;
    using (var context = new Context(GetConnection()))
    {
        allPeople = context.People
            .Include(_ => _.Info)
            .Include(_ => _.Children)
            .ToList();
    }
    // This is an in memory query because to the previous ToList
    // Take care of == because is an in memory case sensitive query!
    Assert.IsNotNull(allPeople.Single(p => p.Name == "Joe").Info);
    Assert.IsNotNull(allPeople.Single(p => p.Name == "Joe's Dad").Children.Single(p => p.Name == "Joe").Info);
    Assert.IsTrue(object.ReferenceEquals(allPeople.Single(p => p.Name == "Joe").Info, allPeople.Single(p => p.Name == "Joe's Dad").Children.Single(p => p.Name == "Joe").Info));
