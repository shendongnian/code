    public T GetItem<T>(int id) where T : ITableEntity, new()
    {
        lock (locker)
        {
            return database.Table<T>().Where(x => x.Id == id).FirstOrDefault();
        }
    }
