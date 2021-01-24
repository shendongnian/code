    public virtual void Save(T element)
    {
        CreateID(element);
        if (!RuntimeCache.Any(x => x.ID == element.ID))
        {
            RuntimeCache.Add(element);
        }
        element.UpdateChangeDate();
        RunDBQueryAsync((conn) =>
        {
            conn.InsertOrReplaceWithChildren(element);
            // Delete orphaned children
            conn.Execute("DELETE FROM B WHERE IDofA IS NULL');
        });
    }
