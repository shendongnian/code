    public class Node
    {
        public Node(string value)
        {
            Value = value;
            Children = new List<Node>();
        }
        
        public string Value { get; }
    
        public List<Node> Children{ get; }
    }
