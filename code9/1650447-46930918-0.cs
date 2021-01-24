    private void OpenTree(TreeNode node)
    {
    	List<TreeNode> parents = new List<TreeNode>();
    	parents.Add(node); // Add the actual node to expand
    
    	TreeNode actPa = node;
    	do
    	{
    		actPa = actPa.Parent;
    		if (actPa != null)
    			parents.Add(actPa);     // Add all the parent node
    	}
    	while (actPa != null);
    
    	if(parents.Count > 0)
    	{
    		for(int iRep = parents.Count - 1; iRep >= 0; iRep --)
    		{
    			parents[iRep].Expand();
    		}
    	}
    }
