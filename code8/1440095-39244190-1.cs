    PurchaseOrder p = new PurchaseOrder();
    BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy;
    PropertyInfo[] iNewPropertyInfos = typeof(INew).GetProperties(bindingFlags);
    var props = p.GetType().GetProperties(bindingFlags).Where(x => iNewPropertyInfos.All(y => y.ToString() != x.ToString()));
    foreach (var prop in props)
    {
        Console.WriteLine(prop.Name);
    }
