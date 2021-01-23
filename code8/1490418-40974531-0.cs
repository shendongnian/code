    public class SyntaxTreeNode 
    {
        // A node can contain other nodes
        public ObservableCollection<SyntaxTreeNode> SyntaxTreeNodes { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
