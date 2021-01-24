    /// <summary>
    /// Gets the underlying type bound to an IList. For example, if the list
    /// is List{string}, the result will be typeof(string).
    /// </summary>
    public static Type GetBoundType( this IList list )
    {
        Type type = list.GetType();
    
        Type boundType = type.GetInterfaces()
            .Where( x => x.IsGenericType )
            .Where( x => x.GetGenericTypeDefinition() == typeof(IList<>) )
            .Select( x => x.GetGenericArguments().First() )
            .FirstOrDefault();
    
        return boundType;
    }
