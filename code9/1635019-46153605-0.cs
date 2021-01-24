    public class Node
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public List<Node> Children { get; } = new List<Node>();
    }
