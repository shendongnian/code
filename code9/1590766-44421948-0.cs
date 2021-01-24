    if (innerList.GetType().IsGenericType && innerList.GetType().GetGenericTypeDefinition() == typeof(List<>))
    {
        var list = (IList)innerList;
        for (int inner = 0; inner < list.Count; inner++)
        {
            Console.WriteLine(list[inner].ToString());
            //print string
        }
    }
