    bases
    .GroupBy(x=>x.Name)
    .Select(x=>
        new Person
        {
            Name =x.Key, 
            PersonDates = x.Select(
                    y=>new PersonDates{
                    StartDate=y.StartDate, 
                    EndDate =y.EndDate})
                .ToList()
        }
    );
