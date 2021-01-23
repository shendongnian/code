    var key1Collection = vertices["Key1"].Cast<object>().ToList();
    var result = vertices
                     //Get all the items belonging to the other keys
                     .Where(item => item.Key != "Key1")
                     //Flatten inner collection
                     .SelectMany(item => item.Value.Cast<object>())
                     //Check to see if their is any shared part
                     .Intersect(key1Collection)
                     //Check that result has at least 1 item
                     .Any();
