    object[] items = null;
    var type = obj.GetType();
    if (type.IsGeneric && GetItems.TryGetValue(type.GetGenericTypeDefinition(), out var itemGetter)) {
        items = itemGetter(obj);
    }
