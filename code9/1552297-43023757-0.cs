    public Item Fetch(string id)
    {
        Item Empty = null;
        foreach (Item i in _items)
        {
            if (i.AreYou(id) == true)
                return i;
        }
        return Empty;  // We didn't find any matches
    }
