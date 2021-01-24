    var contact = new SyncContact { FirstName="Test", LastName="Person", Phone="123-123-1234", Email="test@test.com"};
    var collection = contact.GetType().GetProperties()
        .Select(x => new
        {
            x.GetCustomAttribute<SyncProperty>().PropertyName,
            Value = x.GetValue(contact).ToString()
        })
        .ToDictionary(x => x.PropertyName, x => x.Value);
