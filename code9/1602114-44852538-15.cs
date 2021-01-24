    [System.Serializable]
    public class InventoryModel
    {
        public List<Item> Items;
    }
    
    [System.Serializable]
    public class Item
    {
        public int inventorySlot;
        public string itemID;
        public int amount;
    }
