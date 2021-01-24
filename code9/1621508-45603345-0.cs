    public class SWAChecklist
    {
    
        public SWAChecklist()
        {
            this.Steps = new Steps() { SWAChecklist = this };
            this.Observers = new List<Observer>();
            this.PersonnelObserved = new List<PersonObserved>();
            this.JobFactors = new JobFactors() { SWAChecklist = this };
            this.Causes = new Causes() { SWAChecklist = this };
            this.Hazards = new Hazards() { SWAChecklist = this };
        }
        [Key]
        public int ID { get; set; }        
        public string Status { get; set; }
        public string Job { get; set; }
        public virtual Causes Causes { get; set; }
    }
    
    public class Causes
    {
        [Key]
        [ForeignKey("SWAChecklist")]
        public int ID { get; set; }
        [Required]
        
        public bool? AdditionalHazard { get; set; }
        public bool? UnsafeBehavior{ get; set; }
        public bool? Planned { get; set; }
        public virtual SWAChecklist SWAChecklist { get; set; }
    }
