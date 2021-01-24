    private List<T> GetVideosSection<T>(IEnumerable<ContentAreaItem> items)
    {
        if (items == null) throw new ArgumentNullException("items");
        List<T> blocks = new List<T>();
        foreach (var reference in items)
        {
            var block = _repo.Get<T>(reference.ContentLink);
            blocks.Add(block);
        }
        return blocks;
    }
