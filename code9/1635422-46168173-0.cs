	public class TreeNode
	{
	    public string Name { get; set; }
	
	    public Subject<TreeNode> ChildNodes { get; set; }
			= new Subject<TreeNode>();
	}
