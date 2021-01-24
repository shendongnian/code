    public static IEnumerable<string> RemoveSameSuccessiveItems(this IEnumerable<string> items)
    {  
        string previousItem = null;
        foreach(var item in list)
        {
            if (item.Equals(previousItem) == false)
            {
                previousItem = item;
                yield item;
            }
        }
    }
