    static public IEnumerable ToGenericList(this ArrayList input, Type itemType)
    {
        return (IEnumerable) typeof(List<>)
            .MakeGenericType(itemType)
            .InvokeMember(
                null, 
                BindingFlags.CreateInstance, 
                null, 
                null, 
                new object[] { input.ToArray(itemType) }
            );
    }
