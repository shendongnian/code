     public class SystemMenu
    {
        public SystemMenu()
        {
            Details = new HashSet<SystemMenu>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Controller { get; set; }
        [StringLength(50)]
        public string Action { get; set; }
        [ForeignKey("ParentId")]
        
        public SystemMenu Parent { get; set; }
        [Display(Name = "Parent")]
        public int? ParentId { get; set; }
        [StringLength(50)]
        public string Icon { get; set; }
        [StringLength(50)]
        public string Module { get; set; }
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool FixHeader { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [StringLength(50)]
        public string Size { get; set; }
        public ICollection<SystemMenu> Details { get; set; }
    }
