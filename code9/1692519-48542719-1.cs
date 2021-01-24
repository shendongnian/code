    var CarOwningMales = myDbContext.Persons
        .Where(person => person.Gender == Gender.Male
            && person.Items.Where(item => item.Name == "Car").Any())
        .Select(person => new
        {   
            // TODO: select the properties you plan to use 
        });
