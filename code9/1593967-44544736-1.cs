    var originalNodes = new List<TreeNode>(); // TreeNodeCollection 
    var nodes = new List<TreeNode>();         // TreeNodeCollection 
    var parentByName = nodes.ToDictionary(n => n.Text, n => n.Parent);
    foreach(var originalNode in originalNodes)
    {
        TreeNode parent;
        if (!parentByName.TryGetValue(originalNode.Text, out parent))
        {
            // removed - there is no key for original node name
            continue;
        }
        if (originalNode.Parent?.Text != parent?.Text)
        {
            // moved from originalNode.Parent to parent
            continue;
        }
    }
    // these guys are added
    var added = parentByName.Keys.Except(originalNodes.Select(n => n.Text))
