    public class foo
    {
        public int ID { get; set; }
    
        public virtual Book {get; set;}
    
        public int BookID {get; set; }
    
        public virtual ICollection<Theme> Themes {get; set;}
    
    }
    
    public class Theme
    {
        public int ID { get; set; }
    
        [Foreignkey("fooID")]
        public virtual foo foo{get; set;}
    
        public int fooID {get; set; }
    
    }
