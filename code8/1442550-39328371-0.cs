    var materialized = query
                      .AsQueryable()
                      .Provider
                      .GetType()
                      .GetGenericTypeDefinition() == typeof(EnumerableQuery<>);
