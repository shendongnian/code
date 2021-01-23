    public static void ObjectCollection<TC, TK>(ICollection source, TC target)
        where TC : class, ICollection<TK>, new()
        where TK : class, new()
    {
        foreach (var item in source)
        {
            var copiedItem = new TK();
            ObjectCopy(item, copiedItem);
            target.Add(copiedItem);
        }
    }
