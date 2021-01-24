    DateTimeOffset endDate = DateTimeOffset.UtcNow;
     await new Table<MyEntity>(_session).Where(e => e.Id == entity.Id)
        .Select(u => new MyEntity
        { 
            EndDate = endDate
        })
        .Update()
        .ExecuteAsync();
