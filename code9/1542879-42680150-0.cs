    public static bool Contains(Node root, int value)
    {
        bool status = false;
        if (root == null)
        {
            status = false;
        }
        else if (root.Value == value)
        {
            status = true;
            return true;
        }
        else if (root.Value < value)
        {
            status = Contains(root.Right, value);
        }
        else
        {
            status = Contains(root.Left, value);
        }
        return status;
    }
