    var list = new List<Entity>();
    foreach (var entity in <get all entities>) {
        if (filters(entity)) {
            list.Add(entity)
        }
    }
    return list;
