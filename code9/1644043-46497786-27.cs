    static public ICollection ToGenericList(this ICollection input, Type itemType)
    {
        return (ICollection) typeof(List<>)
            .MakeGenericType(itemType)
            .InvokeMember(
                null, 
                BindingFlags.CreateInstance, 
                null, 
                null, 
                new object[] { new ArrayList(input).ToArray(itemType) }
            );
    }
