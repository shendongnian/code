    public class Item
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Item(string Id, string Content)
        {
            this.Id = Id;
            this.Content = Content;
        }
    }
