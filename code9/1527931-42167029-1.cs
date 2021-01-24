    public class CollectionClearingContractResolver : DefaultContractResolver
    {
        static void ClearGenericCollectionCallback<T>(object o, StreamingContext c)
        {
            var collection = o as ICollection<T>;
            if (collection == null || collection is Array || collection.IsReadOnly)
                return;
            collection.Clear();
        }
        static SerializationCallback ClearListCallback = (o, c) =>
            {
                var collection = o as IList;
                if (collection == null || collection is Array || collection.IsReadOnly)
                    return;
                collection.Clear();
            };
        protected override JsonArrayContract CreateArrayContract(Type objectType)
        {
            var contract = base.CreateArrayContract(objectType);
            if (!objectType.IsArray)
            {
                if (typeof(IList).IsAssignableFrom(objectType))
                {
                    contract.OnDeserializingCallbacks.Add(ClearListCallback);
                }
                else if (objectType.GetCollectItemTypes().Count() == 1)
                {
                    MethodInfo method = typeof(CollectionClearingContractResolver).GetMethod("ClearGenericCollectionCallback", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                    MethodInfo generic = method.MakeGenericMethod(contract.CollectionItemType);
                    contract.OnDeserializingCallbacks.Add((SerializationCallback)Delegate.CreateDelegate(typeof(SerializationCallback), generic));
                }
            }
            return contract;
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type> GetCollectItemTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
        }
    }
    public static class JsonExtensions
    {
        public static void Populate<T>(this JToken value, T target) where T : class
        {
            value.Populate(target, null);
        }
        public static void Populate<T>(this JToken value, T target, JsonSerializerSettings settings) where T : class
        {
            using (var sr = value.CreateReader())
            {
                JsonSerializer.CreateDefault(settings).Populate(sr, target);
            }
        }
    }
