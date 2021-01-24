    public static bool Search(Node root, int value)
    {
    
           if (root != null)
           {
                if (root.Value == value)
                {
                    return true;
                }
                else if (root.Value < value)
                {
                    return Search(root.Right, value);
                }
                else
                {
                    return Search(root.Left, value);
                }
    
           }            
           return false;            
    }
