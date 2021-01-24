     public class CallingClass
    {
        public void BFS(GraphNode v)
        {
            MyQueue<GraphNode> queue = new MyQueue<GraphNode>(); // error, can't implicit convert GraphNode to MyLinkNode<T>
           // MyGraphQueue queue = new MyGraphQueue(); //It's how I do now.
        }
    }
    public class QueueItem
    {
        public QueueItem Next { get; set; }
        public QueueItem Prev { get; set; }
    }
    public class MyQueue<T> where T : QueueItem
    {
        private T Head;
        private T Last;
        public MyQueue() {  }
        public void Enqueue(T item)
        {
            item.Prev = Last;
            Last.Next = item;
            Last = item;
        }
    }
    
    public class MyLinkNode<T>: QueueItem
    {
        public T data { get; set; }
        
    }
    public class GraphNode : MyLinkNode<string>
    {
        public GraphNode()
        {
            this.adjacencyNodes = new List<GraphNode>();
            this.isVisited = false;
        }
        public List<GraphNode> adjacencyNodes;
        public bool isVisited { get; set; }
    }
