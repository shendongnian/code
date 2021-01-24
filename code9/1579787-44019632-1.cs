    public partial class Rule
    {
        [Key, ForeignKey("Item")]
        public string ModuleId { get; set; }
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
