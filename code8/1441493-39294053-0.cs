    public int SaveItem<T>(T item) where T : IMyEntity {
        lock (locker) {
            if (item.Id != 0) {
                context.Set(typeof(T)).Add(item);
            }
            context.SaveChanges();
            return item.Id;
        }
    }
