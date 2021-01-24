    [System.Serializable]
    public class InventoryModel
    {
        public List<Item> Items;
    }
    
    [System.Serializable]
    public class Item
    {
        public int inventorySlot {get; set;}
        public string itemID {get; set;}
        public it amount {get; set;}
    }
