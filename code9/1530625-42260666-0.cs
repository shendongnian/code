    private static Dictionary<ushort, Type> _typeMap = new Dictionary<ushort, Type>()
                                                       {
                                                           { 1, typeof(TestEntity) },
                                                           { 2, typeof(OtherEntity) }
                                                       };
    private EntityBase CreateEntity(ushort id)
    {
        var type = _typeMap[id];
        return (EntityBase) Activator.CreateInstance(type);
    }
