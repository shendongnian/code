    var query = from x in ...
        join business in dbContext.Businesses on ...
        from businesses in bus.DefaultIfEmpty()
        join person in dbContext.People on ...
        from people in peo.DefaultIfEmpty()
        select new Party
        {
            Name = business.Name ?? person.FirstName,
            person.LastName
        };
    
    var result = whereQuery
            .OrderBy(x => x.Name)
            .ThenBy(x => x.PersonLastName);
