    public class BdoSystem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
        
        public int? ParentSystemId { get; set; }
        public virtual BdoSystem ParentSystem { get; set; }
    }
