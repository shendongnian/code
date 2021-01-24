    context.Users.Add(new Sales() {
        Id = 1
    });
    
    context.SaveChanges();
    
    // This will actually be of type "Sales"
    var salesPerson = context.Persons.Single(u => u.Id == 1);
