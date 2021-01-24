    var malesWithTheirCars = myDbContext.Persons
        .Where(person = person.Gender == Gender.Male)
        .Select(person => new
        {
            Name = person.Name,
            ...
            Cars = person.Items.Where(item.Name == "Car").ToList(),
        });
