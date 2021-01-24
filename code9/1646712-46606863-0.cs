    public class Malfunction
    {
        public int Id { get; set; }
    
        [Required]
        public virtual Movie Movie { get; set; }
    
        [Required]
        public virtual Customer Customer { get; set; }
    
        [Required]
        [StringLength(255)]
        public string ReportDescription { get; set; }
    
        public DateTime DateReported { get; set; }
    }
