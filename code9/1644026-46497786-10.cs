    static public System.Collections.IEnumerable ToGenericList(this ArrayList input, Type itemType)
    {
        var typeOfTargetList = typeof(List<>).MakeGenericType(itemType);
        var array = input.ToArray(itemType);
        var targetList = typeOfTargetList.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, new object[] { array });
        return (IEnumerable)targetList;
    }
