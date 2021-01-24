	public class TreeNode
	{
	    public string Name { get; set; }
	
	    public Subject<TreeNode> ChildNodes { get; }
			= new Subject<TreeNode>();
	}
