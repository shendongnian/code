    static public object ToGenericList(this ArrayList input, Type itemType)
    {
        var typeOfTargetList = typeof(List<>).MakeGenericType(itemType);
        var targetList = typeOfTargetList.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, new object[] { input.Count });
        var add = typeOfTargetList.GetMethod("Add");
        foreach (var item in input)
        {
            add.Invoke(targetList, new object[] { item });
        }
        return targetList;
    }
