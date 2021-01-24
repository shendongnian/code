    public class Component : BaseModel
        {
    
            [Required]
            public string Name { get; set}
            public virtual ICollection<ComponentInstance> ComponentInstances { get; set; }
            [ForeignKey("Title")]
            public Title Title {get ; set;}
        }
