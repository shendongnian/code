    result = foos
        .GroupBy(
            outerFoo => outerFoo.X,
            (x, xFoos) => xFoos
                .GroupBy(
                    innerFoo => innerFoo.Y,
                    (y, yFoos) => new
                    {
                        Foos = yFoos,
                        Aggregate = yFoos.Aggregate(
                            (Count: 0, MaxZ: int.MinValue),
                            (accumulator, foo) =>
                                (Count: accumulator.Count + 1,
                                 MaxZ: Math.Max(accumulator.MaxZ, foo.Z)))
                    })
                .Aggregate(
                    new
                    {
                        Foos = Enumerable.Empty<Foo>(),
                        Aggregate = (Count: 0, MaxZ: int.MinValue)
                    },
                    (accumulator, grouping) =>
                        grouping.Aggregate.Count > accumulator.Aggregate.Count
                            || grouping.Aggregate.Count == accumulator.Aggregate.Count
                                && grouping.Aggregate.MaxZ > accumulator.Aggregate.MaxZ
                            ? grouping : accumulator)
                .Foos);
