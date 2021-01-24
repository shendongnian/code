    var myProps = new Dictionary<string, object>()
    {
        { nameof(Registration.AdminFee), 25 },
        { nameof(Registration.AnotherProp1), 35 },
        { nameof(Registration.AnotherProp2), 18 },
        { ... }
    };
    foreach (var matchingProp in modelBuilder.Entity<Registration>()
                .Metadata
                .GetProperties()
                .Where(x => myProps.ContainsKey(x.Name)))
    {
        matchingProp.Relational().DefaultValue = myProps[matchingProp.Name];
    }
