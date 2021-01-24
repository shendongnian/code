    var types = new Type[] {typeof(DemoClass1), typeof(DemoClass1)};
    foreach (var type in types)
    {
        if (typeof(IDemoInterface).IsAssignableFrom(type))
        {
            var instance = Activator.CreateInstance(type) as IDemoInterface;
            instance.DemoMethod();
        }
    }
