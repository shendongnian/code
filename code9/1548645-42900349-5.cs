    public static bool Contains(Node root, int value) {
        Console.WriteLine("value=" + value);
        if (root == null) {
            return false;
        }
        else if (value == root.Value) {
            return true; 
        } 
        else if (value < root.Value) {
            // Hint 2: If a value being searched for is smaller than the value of the node, 
            // then the right subtree can be ignored.
            return Contains(root.Left, value);
        }
        else {
            return Contains(root.Right, value);
        }
        return false;
    }
