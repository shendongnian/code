    MyEntityTypeViewModel found = db.MyEntity
        .OrderByDescending(c => c.CreationTime)
        .Where(c => c.ParameterColumn == parameter)
        .Select(c => new MyEntityTypeViewModel { 
            CreationTime = c.CreationTime,
            ParameterColumn = c.ParameterColumn })
        .First();
