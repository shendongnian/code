    public class News
    {
        public Guid Id { set; get; }
        public string Subject { set; get; }
        public int ViewerCounter { set; get; }
        public string MainContent { set; get; }
        public DateTime SubmitDateTime { set; get; }
        public DateTime ModifiedDateTime { set; get; }
        public string PublisherName { set; get; }
        public string PictureAddress { set; get; }
        public string TypeOfNews { set; get; }
    }
