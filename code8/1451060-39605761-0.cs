        var result = bazzers
            .Select(bazzer => bazzer.Bar)
            .Distinct()
            .Select(bar => new
            {
                Bar = bar,
                LoyalFoos = bazzers
                    .GroupBy(bazzer => bazzer.Foo)
                    .Count(group => group.All(bazzer => bazzer.Bar == bar))
            });
