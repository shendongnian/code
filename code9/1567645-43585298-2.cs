    public class FlyerPage
    {
        public Guid Id { get; set; }
        public string Picture { get; set; }
        public int? Page { get; set; }
    
        public string Text { get; set; }
    
        public ICollection<Keyword> Keywords { get; set; }
    
        public Guid FlyerId { get; set; }
    
        public virtual Flyer Flyer { get; set; }
    }
    public class Keyword
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<FlyerPage> FlyerPages { get; set; }
    }
