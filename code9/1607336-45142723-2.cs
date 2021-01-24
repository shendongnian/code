    public static void RegisterClassMap<T>() where T : IHasIdField
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
        {
            //Map the ID field to string. All other fields are automapped
            BsonClassMap.RegisterClassMap<T>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
