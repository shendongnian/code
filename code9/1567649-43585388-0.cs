     public class FlyerPage
    {
        public Guid Id { get; set; }
        public string Picture { get; set; }
        public int? Page { get; set; }
    
        public string Text { get; set; }
    
        public string KeywordsCollection { get; set; }
    
        public Guid FlyerId { get; set; }
    
        public virtual Flyer Flyer { get; set; }
    }
