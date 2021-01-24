    [Test]
    public void GivenADecimalProperty_WhenISortByColumn_ThenItSorts()
    {
        decimal[] decimals = new[] { 7m, 84.3m, 13.4m };
        var repo = decimals.Select(x => new TestDecimalPropertyClass(x));
        TestDecimalPropertyClassRepository testRepository = new TestDecimalPropertyClassRepository(repo);
        var entities = testRepository.GetAll(new Sorting
        {
            SortableEntities = new[]
                {
                new SortableEntity
                {
                    Descending = false,
                    Name = "decimal",
                    Order = 0
                }
            }
        });
            
        List<TestDecimalPropertyClass> list = entities.ToList();
        Assert.That(list.Count(), Is.EqualTo(decimals.Length));
        Assert.That(list.ToArray()[0].Decimal, Is.EqualTo(7m));
        Assert.That(list.ToArray()[1].Decimal, Is.EqualTo(13.4m));
        Assert.That(list.ToArray()[2].Decimal, Is.EqualTo(84.3m));
    }
