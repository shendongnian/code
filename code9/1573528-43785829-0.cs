    public void SetItems(List<B> newItems)
    {
        foreach(string key in items.Keys)
        {
            if(!newItems.Contains(items[key] as B))
                items.Remove(key);
        }
    }
