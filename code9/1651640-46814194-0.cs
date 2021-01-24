    var list = new List<Item> { new Item() { Name = "aob", Age = 11 }, new Item() {Name = "bob", Age = 10},};
    var input = "-name";
    var map = new Dictionary<string, Func<Item, object>>()
    {
        {"name", x => x.Name},
        {"age", x => x.Age}
    };
    if (input.StartsWith('-'))
    {
        var orderby = map[input.Substring(1)];
        var orderedEnumerable = list.OrderByDescending(orderby);
    }
    else
    {
        var orderby = map[input];
        var orderedEnumerable = list.OrderBy(orderby);
    }
