    class CustomResolver : DefaultContractResolver {
        protected override JsonContract CreateContract(Type objectType) {
            // if type implements your interface - serialize it as object
            if (typeof(IExtensibleObject).IsAssignableFrom(objectType)) {
                return base.CreateObjectContract(objectType);
            }
            return base.CreateContract(objectType);
        }
    }
