    var myProps = new Dictionary<string, object>()
    {
        { nameof(Registry.AdminFee), 25 },
        { nameof(Registry.AnotherProp1), 35 },
        { nameof(Registry.AnotherProp2), 18 },
        { ... }
    };
    foreach (var matchingProp in modelBuilder.Entity<Registration>()
                .Metadata
                .GetProperties()
                .Where(x => myProps.ContainsKey(x.Name)))
    {
        matchingProp.Relational().DefaultValue = myProps[matchingProp.Name];
    }
