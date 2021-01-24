    public bool IsTablesHavingUniqueID<TInterface, T>(List<TInterface> tables)
           where T:TInterface
    {
        List<T> _tables = tables.ConvertAll(x => (T)x).ToList();
        return _tables.Distinct().ToList().Count == tables.Count;
    }
