    public List<T> GetSelection<T>(
        string a, Expression<Func<MyTable, T>> columnsToSelect)
    {
        return _myTableRepository.Where(c => c.Name == a).Select(columnsToSelect)
            .ToList();
    }
    public List<MyTable> GetSelection<MyTable>(string a)
    {
        return GetSelection(a, t => t);
    }
