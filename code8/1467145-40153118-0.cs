    list<Entity> entities = ...;
    foreach(PropertyInfo propertyInfo in typeof(Entity).GetProperties())
    {
        if(entities.All(entity => propertyInfo.GetValue(entity, null) == null))
        {
            Console.WriteLine("{0} property is null in all of the items in the list", propertyInfo.Name);
        }
    }
