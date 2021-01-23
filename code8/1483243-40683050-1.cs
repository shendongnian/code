      public class Guy
    {
        public int GuyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guy()
        {
        }
        public Guy(int GuyId, string Title, string Content)
        {
            this.GuyId = GuyId;
            this.Title = Title;
            this.Content = Content;
        }
    }
