    var myProps = new Dictionary<string, object>() {
        { "AdminFee", 25 },
        { "AnotherProp1", 35 },
        { "AnotherProp2", 18 },
        { ... }
    };
    foreach (var matchingProp in modelBuilder.Entity<Registration>()
                .Metadata
                .GetProperties()
                .Where(x => myProps.ContainsKey(x.Name)))
    {
        matchingProp.Relational().DefaultValue = myProps[matchingProp.Name];
    }
