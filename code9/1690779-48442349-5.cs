    public IEnumerable<IInventoryItem> Items
    {
        get { return items; }
        set { items = (InventoryItem[])value; }
    }
