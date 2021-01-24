    public class TypeHelperFor<TType>
    {
        public bool HasTypeAttribute<TAttribute>() where TAttribute : Attribute
        {
            return typeof(TType).GetCustomAttribute<TAttribute>() != null;
        }
    }
    
    public static class TypeHelper
    {
        public static TypeHelperFor<T> For<T>(this T obj)
        {
            return new TypeHelperFor<T>();
        }
    }
    
    // The ideal, but unsupported
    TypeHelper.HasTypeAttribute<SerializableAttribute>(instance);
    // Chained
    TypeHelper.For(instance).HasTypeAttribute<SerializableAttribute>();
    // Straight-forward/non-chained
    TypeHelper.HasTypeAttribute<SerializableAttribute, MyClass>(instance);
