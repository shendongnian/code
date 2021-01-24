    public class TreeItem
    {
        public long Id { get; set; }
        [Column("tree_id")]
        public int TreeId { get; set; }
        [ForeignKey("TreeId")]
        public virtual Tree Tree { get; set; }
        public string Model { get; set; }
        public string Version { get; protected set; }
        public string Index { get; protected set; }
    }
    public class Tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
