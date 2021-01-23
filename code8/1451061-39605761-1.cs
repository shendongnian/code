        var result = bazzers
            .Select(bazzer => bazzer.Bar)
            .Distinct()
            .Select(bar => new
            {
                Bar = bar,
                LoyalFoos = bazzers
                    .GroupBy(bazzer => bazzer.Foo)
                    .Where(group => group.All(bazzer => bazzer.Bar == bar))
                    .SelectMany(group => group)
            });
