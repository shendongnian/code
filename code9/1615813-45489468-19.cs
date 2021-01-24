    List<Person> allPeople;
    
    using (var context = new Context(GetConnection()))
    {
        allPeople = context.People
            .Include(_ => _.Info)
            .Include(_ => _.Children)
            .AsNoTracking()
            .ToList();
    }
    
    // This throw an exception
    Assert.IsNotNull(allPeople.Single(p => p.Name == "Joe's Dad").Children.Single(p => p.Name == "Joe").Info);
