    private void PopulateTreeView()
    {
    	//read from file
    	var lines = File.ReadAllLines(@"c:\temp\tree.txt");
    	//go through all the lines
    	foreach (string line in lines)
    	{
    		//split by dot to get nodes names
    		var nodeNames = line.Split('.');
    		//TreeNode to remember node level
    		TreeNode lastNode = null;
    
    		//iterate through all node names
    		foreach (string nodeName in nodeNames)
    		{
    			//values for name and tag (tag is empty string by default)
    			string name = nodeName;
    			string tagValue = string.Empty;
    			//if node is in format "name=value", change default values of name and tag value. If not, 
    			if (nodeName.Contains("="))
    			{
    				name = nodeName.Split('=')[0];
    				tagValue = nodeName.Split('=')[1];
    			}
    
    			//var used for finding existing node
    			TreeNode existingNode = null;
    			//new node to add to tree
    			TreeNode newNode = new TreeNode(name);
    			newNode.Tag = tagValue;
    			//collection of subnodes to search for node name (to check if node exists)
    			//in first pass, that collection is collection of treeView's nodes (first level)
    			TreeNodeCollection nodesCollection = treeView1.Nodes;
    
    			//with first pass, this will be null, but in every other, this will hold last added node.
    			if (lastNode != null)
    			{
    				nodesCollection = lastNode.Nodes;
    			}
    
    			//look into collection if node is already there (method checks only first level of node collection)
    			existingNode = FindNode(nodesCollection, name);
    			//node is found? In that case, skip it but mark it as last "added"
    			if (existingNode != null)
    			{
    				lastNode = existingNode;
    				continue;
    			}
    			else //not found so add it to collection and mark node as last added.
    			{
    				nodesCollection.Add(newNode);
    				lastNode = newNode;
    			}
    		}
    	}
    
    	treeView1.ExpandAll();
    }
    private TreeNode FindNode(TreeNodeCollection nodeCollectionToSearch, string nodeText)
    {
    	var nodesToSearch = nodeCollectionToSearch.Cast<TreeNode>();
    	var foundNode = nodesToSearch.FirstOrDefault(n => n.Text == nodeText);
    	return foundNode;
    }
