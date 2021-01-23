    public class Work{
    // Primary key
    public int WorkId { get; set; }
    
    // Foreign key
    public virtual Work Work { get; set; }
    
    public virtual ICollection<Work> RelatedMultipleWorks { get; set; }
    }
