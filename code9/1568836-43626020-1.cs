    public class TreeItem
    {
        public int ID { get; set; }
        public TreeItem Parent { get; set; }
        public List<TreeItem> Children { get; set; }
        public TreeItem(int id)
        {
            ID = id;
            Children = new List<TreeItem>();
        }
        public TreeItem(int id, TreeItem parent) : this(id)
        {
            Parent = parent;
        }
    }
