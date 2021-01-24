    public class ParentType
    {
        [Key]
        public int ParentTypeId { get; set; }
        public string ParentTypeName { get; set; }
        public virtual IEnumerable<Parent> Parents { get; set; }
    }
