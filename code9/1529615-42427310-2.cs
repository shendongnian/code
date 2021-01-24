     // Creates a binary tree.
    
        class BinarySearchTree
        {
            public Node root; // Creates a root node.
    
            public  BinarySearchTree() 
            {
                this.root = null;
            }
    
            // Adds a node in the binary tree.
    
            public void Insert(string inputValue)
            {
                Node newNode = new Node(inputValue); // Creates a new node.
    
                if (root == null) // If the tree is empty, inserts the new node as root
                {
                    root = newNode;                
                    return;
                }
    
                //Determins where to place the new node in the binary tree.
    
                Node current = root;
                Node parent = null;             
    
                while (true)
                {
                    parent = current;
                    if (inputValue.CompareTo(current.Data) < 0)
                    {
                        current = current.LeftChild;
                        if (current == null)
                        {
                            parent.LeftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.RightChild;
                        if (current == null)
                        {
                            parent.RightChild = newNode;
                            return;
                        }
                    }
                }
            }
    
            // Checks if the node exists in the binary tree
    
            public bool Find(string inputValue)
            {
                Node current = root;
                while (current != null)
                {
                    if (current.Data.Equals(inputValue))
                    {
                        return true;
                    }
                    else if (current.Data.CompareTo(inputValue) > 0)
                    {
                        current = current.LeftChild;
                    }
                    else
                    {
                        current = current.RightChild;
                    }
                }
                return false;
            }
    
            // Creates a method to find the lowest common ancestor(LCA).
    
            public object SearchLCA(Node searchTree, string compareValue1, string compareValue2)
            {
                if (searchTree == null)
                {
                    return null;
                }
                if (searchTree.Data.CompareTo(compareValue1) > 0 && searchTree.Data.CompareTo(compareValue2) > 0)
                {
                    return SearchLCA(searchTree.LeftChild, compareValue1, compareValue2);
                }
                if (searchTree.Data.CompareTo(compareValue1) < 0 && searchTree.Data.CompareTo(compareValue2) < 0)
                {
                    return SearchLCA(searchTree.RightChild, compareValue1, compareValue2);
                }
                return searchTree.Data;
            }        
        }
