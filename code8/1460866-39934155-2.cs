    var key1Collection = vertices["Key1"].Cast<object>().ToList();
    var result = vertices
                     //Get all other keys
                     .Where(item => item.Key != "Key1")
                     //Check if for any of them, all the items in their collection are contained in the "key1" collection
                     .Any(item => item.Value.Cast<object>()
                                            .All(item => key1Collection.Contains(item));
