    public class Item
    {
        public int Item Id { get; set; }
        public string Name { get; set; }
        public int? ForeignKeyItemId { get; set; }
        public ForeignKeyItem ForeignKeyItem { get; set; }
    }
