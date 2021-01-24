    var ids = new[] { "Factors.Item1", "Factors.Item_Check"}
                .Select( v => bindingContext
                              .ValueProvider
                              .GetValue(v)
                              .AttemptedValue
                      )
                .ToArray(); // materialize if you need to
