    class TreeBuilder<T>
    {
        private int level;
        private int nodeCount;
        public Node<T> Root { get; }
        public TreeBuilder(T data)
        {
            Root = new Node<T>(data);
            nodeCount = 1;
            level = 0;
        }
        public void addNode(T data)
        {
            nodeCount++;
            Node<T> current = Root;
            if (nodeCount >= Math.Pow(2, level + 1)) level++;
            for (int n=level - 1; n>0; n--)
                current = checkBit(nodeCount, n) ? current.Left : current.Right;
            if (checkBit(nodeCount, 0))
                current.Left = new Node<T>(data);
            else
                current.Right = new Node<T>(data);
        }
        private bool checkBit(int num, int position)
        {
            return ((num >> position) & 1) == 0;
        }
    }
