    public class ViewModel
    {
        public ObservableCollection<Node> Nodes { get; private set; }
        public ViewModel()
        {
            Nodes = new ObservableCollection<Node>();
            Node parent = new Node("Parent", "Parent2");
    
            for (int i = 0; i < 5000; i++)
                parent.Children.Add(new Node(i.ToString(), (i * i).ToString()));
    
            Nodes.Add(parent);
        }
    }
    
    public class Node
    {
        public string Data { get; set; }
        public string Data2 { get; set; }
    
        public List<Node> Children { get; set; }
        public Node(string data, string data2)
        {
            Data = data;
            Data2 = data2;
            Children = new List<Node>();
        }
    }
