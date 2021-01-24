    internal static class TypeEx
    {
        public static IEnumerable<Type> GetBaseTypes( this Type type )
        {
            yield return type;
            while( type.BaseType != null )
            {
                type = type.BaseType;
                yield return type;
            }
        }
    }
