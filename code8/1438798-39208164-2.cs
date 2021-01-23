    public class Application 
    {
        public int Id { get; set; }
    
        public virtual ApplicationSubcontractor ApplicationSubcontractor { get; set; }
    }
        
    
    public class ApplicationSubcontractor
    {
        [Key, ForeignKey("Application")]
        public override int Id { get; set; }
    
        public virtual Application Application { get; set; }
    }
