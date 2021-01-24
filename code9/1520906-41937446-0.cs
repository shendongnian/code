    private void RemoveOrphans<T>(Predicate<T> where)
    {
        var items = context.Set<T>().Where(where).ToList();
        if (items != null)
        {
            foreach (var item in items)
            {
                context.Set<T>().Remove(item);
            }
        }
        context.SaveChanges();
    }
