    static List<Node> BuildTree(List<Node> nodes)
    {
    	var nodeMap = nodes.ToDictionary(node => node.id);
    	var rootNodes = new List<Node>();
    	foreach (var node in nodes)
    	{
    		Node parent;
    		if (nodeMap.TryGetValue(node.parentId, out parent))
    			parent.children.Add(node);
    		else
    			rootNodes.Add(node);
    	}
    	return rootNodes;
    }
