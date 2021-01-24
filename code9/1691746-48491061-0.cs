    public abstract class BinaryTree<T>
    {
    	public T Data { get; set; }
    	public BinaryTree<T> Left { get; set; }
    	public BinaryTree<T> Right { get; set; }
    }
    /// <summary>
    /// Checks shape of the trees
    /// </summary>
    public static bool CompareTreeShapes(BinaryTree<int> tree1, BinaryTree<int> tree2)
    {
    	// Empty trees are equal
    	if (tree1 == null && tree2 == null)
    	{
    		return true;
    	}
    	// Empty tree is not equal to a non-empty one
    	if ((tree1 == null) != (tree2 == null))
    	{
    		return false;
    	}
    	// Otherwise check recursively both parts: left and right
    	return CompareTreeShapes(tree1.Left, tree2.Left) && CompareTreeShapes(tree1.Right, tree2.Right);
    }
