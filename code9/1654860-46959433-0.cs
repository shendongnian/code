    var person = new Person { Id = 1, Name = "John Doe" };
    var expando = new ExpandoObject();
    var dictionary = (IDictionary<string, object>)expando;
    foreach (var property in person.GetType().GetProperties())
        dictionary.Add(property.Name, property.GetValue(person));
