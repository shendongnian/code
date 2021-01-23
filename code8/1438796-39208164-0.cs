    public class Application 
    {
       [Key, ForeignKey("ApplicationSubcontractor")]
       public override int Id { get; set; }
    
       public virtual ApplicationSubcontractor ApplicationSubcontractor{get; set;}
    }
    
    
    
    public class ApplicationSubcontractor
    {
       public int Id {get; set;}
    
       pubic virtual  Application Application {get; set;}
    }
