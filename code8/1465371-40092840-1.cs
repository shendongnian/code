    public class Change
    {
        // ...
    
        [Required(ErrorMessage = "Engineer name is required.")]
        [Display(Name = "Engineer")]
        [ForeignKey("Engineer")]
        public int EngineerId { get; set; }
    
        [Required(ErrorMessage = "Manager is required.")]
        [Display(Name = "Manager")]
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
    
        // instead of person property:
        public virtual Person Engineer { get; set; }
        public virtual Person Manager { get; set; }
    }
