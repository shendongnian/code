    public class TreeBuilder
    {
        private Queue<Node> _previousNodes;
        public TreeBuilder()
        {
            _previousNodes = new Queue<Node>();
        }
        public void AddNode(Node node)
        {
            if(_previousNodes.Count > 0)
            {
                Node nodeToAddChildTo = _previousNodes.Peek();
                if(nodeToAddChildTo.Left == null)
                {
                   nodeToAddChildTo.Left = node; 
                }
                else
                {
                    nodeToAddChildTo.Right = node;
                    _previousNodes.Dequeue();
                }      
            }
            _previousNodes.Enqueue(node);
        } 
    }
