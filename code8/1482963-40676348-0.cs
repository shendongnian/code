    class CustomResolver : DefaultContractResolver {
        protected override JsonContract CreateContract(Type objectType) {
            // if type implements your interface - serialize it as object
            if (objectType.GetInterfaces().Any(c => c == typeof(IExtensibleObject))) {
                return base.CreateObjectContract(objectType);
            }
            return base.CreateContract(objectType);
        }
    }
