    private IList readObjects(System.Type objType)
    {
        var listType = typeof(List<>).MakeGenericType(curType);
        var list = (IList)Activator.CreateInstance(listType);
        // ...
        while (_rs.Read())
        {
            // ...
            list.Add(_objItem);
        }
    }
