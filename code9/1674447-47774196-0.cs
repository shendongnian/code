    foreach (var item in (object as IEnumerable).Cast<object>().ToList())
    {
        List<Object> address = item.GetType().GetProperty("Adress").GetValue(item) as List<Object>;
        foreach(var ad in address)
        {
        	//do what you want here
        }
    }
