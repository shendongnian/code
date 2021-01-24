    public T GetItem<T>(int id) where T : ITableEntity, new()
    {
        lock (locker)
        {
            return database.Table<T>().FirstOrDefault(x => x.Id == id);
        }
    }
