    Filter filter = dbContext.Filters.First(x => x.FilterId == filterId);
    
    var pb = new PredicateBuilder<User>();
    foreach(var inclusion in filter.Inclusions)
    {
        if(inclusion.Age.HasValue) 
        {
            pb = pb.And(p => p.Age == inclusion.Age.Value);
        }
        if(!string.IsNullOrWhiteSpace(inclusion.Name))
        {
            pb = pb.And(p => p.Name == inclusion.Name);
        }
    }
    foreach(var exclusion in filter.Exclusions)
    {
        if(exclusion.Age.HasValue) 
        {
            pb = pb.And(p => p.Age != exclusion.Age.Value);
        }
        if(!string.IsNullOrWhiteSpace(exclusion.Name))
        {
            pb = pb.And(p => p.Name != exclusion.Name);
        }
    }
    var filteredUsers = dbContext.Users.AsExpandable().Where(pb);
