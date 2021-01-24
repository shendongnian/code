    int GenerateId<T>(int rowCount, Func<T, int> getIdFunc, Action<T, int> setIdFunc)
        where T : class 
    {
        var maxId = EntityContainer.Set<T>().Max(getIdFunc);
        var newItems = EntityContainer.Set<T>().Where(a => getIdFunc.Invoke(a) == 0);
        foreach (T item in newItems)
        {
            setIdFunc.Invoke(item, maxId++);
            rowCount++;
        }
        return rowCount;
    }
