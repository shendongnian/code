    public class ManagerToEngineer
    {
        [Key]
        public int ManagerToEngineerId { get; set; }
    
        [ForeignKey("engineer")]
        public int EngineerId { get; set; }
    
        [ForeignKey("manager")]
        public int ManagerId { get; set; }
    
        public virtual Engineer engineer { get; set; }
        public virtual Manager manager { get; set; }
    
    }
