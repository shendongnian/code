    int GenerateID<T>(int rowCount, Func<T, int> getIdFunc, Action<T> setIdFunc)
    {
        var maxId = EntityContainer.Set<T>().Max(getIdFunc);
        var newItems = EntityContainer.Set<T>().Where(a => getIdFunc.Invoke(a) == 0);
        foreach (T item in newItems)
        {
            setIdFunc.Invoke(++maxId);
            rowCount++;
        }
        return rowCount;
    }
