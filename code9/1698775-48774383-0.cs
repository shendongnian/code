    private List<MyBlock1> GetVideosSection(IEnumerable<ContentAreaItem> items)
    {
        List<MyBlock1> blocks = null;
        if (items != null)
        {
            blocks = new List<MyBlock1>();
            foreach (var reference in items)
            {
                var block = _repo.Get<MyBlock1>(reference.ContentLink);
                blocks.Add(block);
            }
        }
        return blocks;
    }
