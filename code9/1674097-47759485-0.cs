    Entity entity = new Entity() { FirstPart = new SubPart() { ExtraProperty = 1 } };
    object currentObjectInChain = entity;
    String[] childProperties = ("FirstPart.ExtraProperty").Split('.');
    foreach (var property in childProperties)
    {
        if (currentObjectInChain == null)
        {
            throw new ArgumentException("Current value is null");
        }
        var type = currentObjectInChain.GetType();
        var param = Expression.Parameter(type);
        var lambda = Expression.Lambda(
            Expression.PropertyOrField(param, property),
            param).Compile(); // cache based on type and property name
        currentObjectInChain = lambda.DynamicInvoke(currentObjectInChain);
    }
