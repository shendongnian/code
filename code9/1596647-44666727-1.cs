    public class TodoItem
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public List<Tag> Tags { get; set; }
    }
    public class Tag
    {
        public string Id { get; set; }
        public string TagName { get; set; }
    }
