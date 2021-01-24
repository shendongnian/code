    public class Cis 
    {
        [Key]
        public int CisId { get; set; }
        [ForeignKey("ProjectId")] //here
        public int ProjectId { get; set; }
      
        public virtual ICollection<Overhead> Overheads { get; set; }
    }   
