    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        //FK
        public int LinkId
        public Link Link { get; set; }
    }
    
    public class News
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        //FK
        public int LinkId
        public Link Link { get; set; }
    }
    
    public class Link
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int RowId  { get; set; }
        public string Url { get; set; }
        //FK
        public Item Item { get; set; }
        public News News { get; set; }
    }
