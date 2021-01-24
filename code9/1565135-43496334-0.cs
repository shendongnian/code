    var types = new[] { typeof(Employee), typeof(Department), typeof(Room) };
    var instance = AuditManager.DefaultConfiguration;
    var openGenericMethod = instance.GetType().GetMethod("Exclude");
    foreach (var @type in types)
    {
        var closedGenericMethod = openGenericMethod.MakeGenericMethod(@type);
        closedGenericMethod.Invoke(instance, null);
    }
