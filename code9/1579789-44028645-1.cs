    public partial class Rule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, ForeignKey("Item")]
        public string Id { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public virtual MenuItem Item { get; set; }
        public virtual Module Module { get; set; }
    }
    public partial class MenuItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual Rule RequiredRule { get; set; }
    }
    public partial class Module
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }
