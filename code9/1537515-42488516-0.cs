    public int GetNullProperiesCount(object anyObject)
    {
        var objType = anyObject.GetType();
        var nullCount = 0;
    
        foreach(var propInfo in objType.GetProperties())
        {
            if(propInfo.CanRead)
            {
               object val = propInfo.GetValue(anyValue, null);
               if(val == null) ++nullCount;
            }
        }
        return nullCount;
    }
