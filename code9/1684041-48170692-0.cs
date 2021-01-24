    var type = typeof(yourDeserializedObjectsType);
    var context = new YourContext();
    var dbSet = context.GetType().GetProperties()
        .Where(x => x.PropertyType.GetGenericArguments().Contains(type))
        .First();
