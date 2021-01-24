    int GenerateID<T>() where T : IItem
    {
        var maxId = EntityContainer.Set<T>().Max(a => a.Id);
        var newItems = EntityContainer.Set<T>().Where(a => a.Id == 0);
        foreach (T item in newItems)
        {
            item.Id = ++maxId;
            rowCount++;
        }
    }
