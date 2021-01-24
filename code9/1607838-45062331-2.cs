    var fixture = new Fixture();
    var objs = fixture
        .Build<MyObject>()
        .Without(o => o.PropertyOne)
        .Without(o => o.PropertyTwo)
        .Do(o =>
            {
                o.PropertyOne = fixture.Create<double>();
                o.PropertyTwo = o.PropertyOne;
            })
        .CreateMany()
        .ToList();
