    public static bool Contains(Node root, int value)
    {
        if (root == null)
        {
            return false;
        }
        else if (root.Value == value)
        {
            return true;
        }
        else if (root.Value < value)
        {
            return  Contains(root.Right, value);
        }
        else
        {
            return Contains(root.Left, value);
        }
    }
