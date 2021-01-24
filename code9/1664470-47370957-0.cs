    public List<Inventory> GetFullInventoryList()
    {
        using (var _db = new InventoryContext())
        {
            return _db.Inventory.ToList();
        }
    }
