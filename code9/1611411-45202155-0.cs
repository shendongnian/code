    TreeView t = treeView1;
    
    TreeNode newNode = new TreeNode(nodename);
    newNode.Nodes.Add($"Username: {addedname ?? "Empty"}");
    newNode.Nodes.Add($"Password: {addedpass ?? "Empty"}");
    newNode.Nodes.Add($"Email: {addedemail ?? "Empty"}");
    newNode.Nodes.Add($"Website: {addedwebsite ?? "Empty"}");
    
    t.Nodes.Add(newNode);
