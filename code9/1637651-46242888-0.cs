    int[] paramValue = new int[] { 1, 2, 3 };
    Type type = paramValue.GetType();
    Type underlyingType;
    if (type != typeof(string))
    {
        System.Collections.IEnumerable e = paramValue as System.Collections.IEnumerable;
        if(e != null)
        {
            Type eType = e.GetType();
            if(eType.IsGenericType)
            {
                underlyingType = eType.GetType().GetGenericArguments()[0];
            }
            else
            {
                foreach(var item in e)
                {
                    underlyingType = item.GetType();
                    break;
                }
            }
        }
    }
