    private void insertHelper(int value, BSTNode root)
    {    
        if (root == null) //empty tree, make new node
        {
            BSTNode node = new BSTNode(value);
            this.Root = node;
        }
        else if (value < root.Num)
        {
            if(root.Left != null){
                insertHelper(value, root.Left);
            }else{
                root.Left = new BSTNode(value);
            }
        }
        else if (value > root.Num)
        {
            if(root.Right!= null){
                insertHelper(value, root.Right);
            }else{
                root.Right= new BSTNode(value);
            }
        }
    }
