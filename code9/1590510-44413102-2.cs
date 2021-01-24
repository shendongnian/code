    bool areAllNodesExpanded(TreeNode nodeToCheck){
    	if(!nodeToCheck.IsExpanded)
    		return false;
    	foreach(TreeNode n in nodeToCheck.Nodes){
            if (n.Nodes.Count == 0)
                continue;
    		if(!areAllNodesExpanded(n))
    			return false;
    	}
    	return true;
    }
 
