    static public IEnumerable ToGenericList(this ArrayList input, Type itemType)
    {
        var typeOfTargetList = typeof(List<>).MakeGenericType(itemType);
        var array = input.ToArray(itemType);
        var targetList = typeOfTargetList.InvokeMember(
            null,
            BindingFlags.CreateInstance, 
            null, 
            null, 
            new object[] { array }   //Pass array as a constructor argument
        );
        return (IEnumerable)targetList;
    }
