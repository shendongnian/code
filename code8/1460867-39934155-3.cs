    string key = "Key1";
    var key1Collection = vertices[key].Cast<object>().ToList();
    foreach(var item in vertices.Where(x => x.Key != key ))
    {
        //If you want that all the items of the collection will be in the "Key1" collection:
        if(item.Value.Cast<object>().All(x => key1Collection.Contains(x))
        {
             //Do stuff
        }
        //Or if you want that at least 1 of the items of the collection will be in the "Key1" collection:
        if(item.Value.Cast<object>().Any(x => key1Collection.Contains(x))
        {
             //Do stuff
        }
    }
