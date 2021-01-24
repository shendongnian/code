When the MyEntityType instance is returned via Ok it will be converted to JSON which will read the values of all the public properties and fields. This will cause EF to load the entire entity and all relationships. If you only require specific properties to be returned then use Select() as below.
    var found = db.MyEntity
        .OrderByDescending(c => c.CreationTime)
        .Select(c => new { c.CreationTime, c.ParameterColumn })
        .First(c => c.ParameterColumn == parameter);
