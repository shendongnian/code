        public class ChildClass
        {
            [Key, ForeignKey("Parent")]
            public int SId { get; set; }
            public ParentClass Parent { get; set; }
        }
    
        public class ParentClass
        {
            [Key]
            public int SId { get; set; }
            public ChildClass Child { get; set; }
        }
