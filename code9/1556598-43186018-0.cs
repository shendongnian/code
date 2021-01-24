	public class NodeSorter : IComparer
	{
		public bool Descending {get;set;}
	    public int Compare(object x, object y)
	    {
	        TreeNode tx = x as TreeNode;
	        TreeNode ty = y as TreeNode;
			int result = // Your compare logic here
			if (Descending && result!=0) {
				result = 2 % result + 1;
			}
	        return result;
	    }
	}
