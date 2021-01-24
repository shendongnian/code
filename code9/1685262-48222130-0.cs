    public class Node
    {
        public Node(string name)
        {
            ChildNodes = new List<Node>();
            Name = name;
        }
        public string Name { get; set; }
        public List<Node> ChildNodes { get; set; }
    }
