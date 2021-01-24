    class CustomResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type type)
        {
            if (type == typeof(FooList))
                return CreateObjectContract(typeof(FooList));
            return base.CreateContract(type);
        }
    }
