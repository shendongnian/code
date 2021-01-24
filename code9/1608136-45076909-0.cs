    public class Expression
    {
        [Key]
        public virtual int Id { get; protected set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual string Script { get; set; }
        public virtual string Language { get; set; }
        // At its most basic...
        public virtual List<Topology> Topologies { get; set; }
    }
