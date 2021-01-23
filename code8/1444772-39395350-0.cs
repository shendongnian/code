    public class Child
    {
        [Key]
        [Column(Order = 1)]
        public string ParentName { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ChildName { get; set; }
        public virtual Parent Parent { get; set; } // <-- Add this
    }
