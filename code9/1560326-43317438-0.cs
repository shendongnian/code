    var persons = new[]
    {
        new Person { Name = "John Doe" }
    };
    var names = new[] { "John Doe", "Mr Smith" };
    var res = persons.AsQueryable().Where("@0.Contains(Name)", names).ToArray();
