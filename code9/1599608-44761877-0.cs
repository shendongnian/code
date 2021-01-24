    res = this.dbContext.SomeTable
        .Where(c => c.Id == someId)
        .AsEnumerable() // The following "Select" run in memory
        .Select(c => new SomeModel {
            Id = c.Id
        ,   Name = c.Name
        ,   StartDate = c.StartDate.DateTime // No problem here 
        });
