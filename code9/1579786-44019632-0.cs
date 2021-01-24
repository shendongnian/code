    public partial class Rule
    {
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    
        [ForeignKey("Item")]
        public int ModuleId { get; set; }
        public string Name { get; set; }
    
        public virtual MenuItem Item { get; set; }
    }
    
    public partial class MenuItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual Rule RequiredRule { get; set; }
    }
