    public class Child
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }
    }
