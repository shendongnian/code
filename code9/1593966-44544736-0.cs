    var originalNodes = new List<TreeNode>(); // TreeNodeCollection 
    var nodes = new List<TreeNode>();         // TreeNodeCollection 
    var nodesByName = nodes.ToDictionary(n => n.Text, n => n.Parent);
    foreach(var originalNode in originalNodes)
    {
        TreeNode parent;
        if (!nodesByName.TryGetValue(originalNode.Text, out parent))
        {
            // removed
            continue;
        }
        if (originalNode.Parent?.Text != parent?.Text)
        {
            // moved
            continue;
        }
    }
    // these guys are added
    var added = nodesByName.Keys.Except(originalNodes.Select(n => n.Text))
                                .Select(name => nodesByName[name]);
