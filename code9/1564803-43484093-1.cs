    public class ItemData
    {
        public long ItemId { get; set; }
        public bool Active { get; set; }
        // To make these discoverable, set them to public scope
        public IEnumerable<ItemAttribute> ItemAttributes { get; set; }
        public IEnumerable<string> ItemUrls { get; set; }
        public IEnumerable<InventoryInformation> InventoryInformation { get; set; }
    }
