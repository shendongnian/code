    public class TreeBuilder<T>
    {
        private readonly Queue<Node<T>> _previousNodes;
        public Node<T> Root { get; }
        public TreeBuilder(T rootData)
        {
            Root = new Node<T>(rootData)
            _previousNodes = new Queue<Node<T>>();
            _previousNodes.Enqueue(Root);
        }
        public void AddNode(T data)
        {
            var newNode = new Node<T>(data);
            var nodeToAddChildTo = _previousNodes.Peek();
            if(nodeToAddChildTo.Left == null)
            {
               nodeToAddChildTo.Left = node; 
            }
            else
            {
                nodeToAddChildTo.Right = node;
                _previousNodes.Dequeue();
            }      
            _previousNodes.Enqueue(newNode);
        } 
    }
