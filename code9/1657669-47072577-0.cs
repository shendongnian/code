    public class Parent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index("ParentIdIndex", IsUnique = true)]
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        [ForeignKey("ParentType")]
        public int ParentTypeId { get; set; }
        public virtual ParentType ParentType{ get; set; }
    }
