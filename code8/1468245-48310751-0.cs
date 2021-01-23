     class Node
      {
        private readonly Node parent;
        private Direction lastPath;
    
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    
        public Node(int data, Node parent = null)
        {
          Data = data;
          this.parent = parent;
        }
    
        public Node AddChild(int data)
        {
          if (Left == null)
          {
            lastPath = Direction.Left;
            Left = new Node(data, this);
            return this;
          }
          if (Right == null)
          {
            lastPath = Direction.Right;
            Right = new Node(data, this);
            return parent ?? this;
          }
          
          if (lastPath == Direction.Parent || parent==null && lastPath == Direction.Right)
          {
            lastPath = Direction.Left;
            return Left.AddChild(data);
          }
    
          if (lastPath == Direction.Left)
          {
            lastPath = Direction.Right;
            return Right.AddChild(data);
          }
    
          lastPath = Direction.Parent;
          return parent?.AddChild(data);
        }
      }
    
      enum Direction
      {
        Left,
        Right,
        Parent
      }
    
      class Tree
      {
        public Node Root { get; private set; }
        private Node current;
        
        public void AddNode(int data)
        {
          if (current == null)
          {
            Root = new Node(data);
            current = Root;
          }
          else
          {
            current = current.AddChild(data);
          }
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          var nodeData = new [] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
          var tree1 = new Tree();
    
          foreach (var data in nodeData)
          {
            tree1.AddNode(data);
          }
          Console.ReadKey();
        }
      }
