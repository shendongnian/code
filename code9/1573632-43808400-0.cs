    // Projection (Yield the whole object, not just a property from it)
    var projection = query.AsQueryable().Select(x => new Output()
    {
      Parent1 = x.parent1,
      Parent2 = x.parent2,
      Instance = x.Items.First(y => y.numbers.item2 >= 230000)
    });
    // Sort and get results (Now just sort on the property we care about)
    var result = projection.OrderBy(x => x.Instance.item2).ToList();
