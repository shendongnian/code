    class Tree<T>
    {
        Node<T> root = null;
        int nodeCount = 0;
        public void AddNode(T Data)
        {
            AddNode(new Node<T>(Data));
        }
        public void AddNode(Node<T> Node)
        {
            nodeCount++;
            if (root == null)
                root = Node;
            else
            {
                //First we find the parent node
                Node<T> parent = FindNodeWithAddress(nodeCount >> 1);
                //Then we add left or right
                if (nodeCount % 2 == 0)
                    parent.Left = Node;
                else
                    parent.Right = Node;
            }
        }
        private Node<T> FindNodeWithAddress(int address)
        {
            if (address == 1)
                return root;
            Node<T> parent = FindNodeWithAddress(address >> 1);
            return (address % 2 == 0 ? parent.Left : parent.Right);
        }
    }
