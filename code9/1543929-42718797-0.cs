    List<string> name_list = new List<string>();
    List<string> value_list = new List<string>();
    List<string> price_list = new List<string>();
    // join the lists into a single list
    var combined = Enumerable.Range(0, name_list.Count).Select(i => new
    {
        name = name_list[i],
        value = value_list[i],
        price = price_list[i],
    });
    // here you have a single sorted list that is ordered by 'name'
    var sorted = combined.OrderBy(v => v.name).ToList();
    // if you need to get them back into separate lists again
    var name_list_sorted = sorted.Select(s => s.name).ToList();
    var value_list_sorted = sorted.Select(s => s.value).ToList();
    var price_list_sorted = sorted.Select(s => s.price).ToList();
