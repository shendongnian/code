    public class TreeNode
    {
        public string Name { get; set; }
        public ICollection<TreeNode> Children { get; set; }
        public IDictionary<string, string> Data { get; set; }
    }
