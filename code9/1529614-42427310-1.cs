    // Creates the node structure
    
        class Node
        {
            public string Data { get; set; }
            public Node RightChild { get; set; }
            public Node LeftChild { get; set; }
    
            public Node(string data, Node left = null, Node right = null)
            {
                this.Data = data;
                this.LeftChild = left;
                this.RightChild = right;
            }
        }
