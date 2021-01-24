    private static Dictionary<ushort, Type> TypeMap = new Dictionary<ushort, Type>()
                                                       {
                                                           { 1, typeof(TestEntity) },
                                                           { 2, typeof(OtherEntity) }
                                                       };
    private EntityBase CreateEntity(ushort id)
    {
        var type = TypeMap[id];
        return (EntityBase) Activator.CreateInstance(type);
    }
