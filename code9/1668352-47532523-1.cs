    public class BdoSubSystem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
        public virtual ICollection<BdoSystem> Systems { get; set; }
    }
    public class BdoSystem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public virtual ICollection<BdoSubSystem> SubSystems { get; set; }
    }
