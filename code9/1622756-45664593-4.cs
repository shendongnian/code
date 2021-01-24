    public List<string> GetCheckedItems()
    {
        return _list
                .Where(a => a.IsSelected)
                .Select(b => b.Name)
                .ToList();
    }
