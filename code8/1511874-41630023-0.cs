    public void fillTreeViewByList()
    {
        connect.Open();
    
        TreeViewColorDescNodes firstNode = new TreeViewColorDescNodes();  // Everything from here down is probably wrong...
    
        tvDiscountMaintenance.Nodes.Add("Select All"); 
    	
    	//firstNode has the instance of TreeViewColorDescNodes() which has list of items from DB
    	//So you need to iterate the items from this instance
        foreach (string item in firstNode.ColDescNode)
    	{
    		//You need to create the tree node with text in item rather than List name
    		TreeNode colorDesc = new TreeNode(item);
    		
    		//You need to add the tree node to the tree control rather than the string
    		tvDiscountMaintenance.Nodes[0].Nodes.Add(colorDesc);
    	}
    }
