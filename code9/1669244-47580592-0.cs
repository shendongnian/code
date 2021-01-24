    query = query.Group(
        key => key.Id,
        g => new T1 // replace "T1" with the actual name of your class
        {
            Id = g.Key
        }).ToList(); 
