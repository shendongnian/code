    public class Node
    {
        public Node(string name)
        {
            Name = name;
            InnerNodes = new List<Node>();
        }
        public string Name { get; }
        public string Contents { get; set; }
        public List<Node> InnerNodes { get; }
    }
