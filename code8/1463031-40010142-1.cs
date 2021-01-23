    private void LoadTree()
    {
        // Get a list of everything under the users' temp folder as an example
        string[] fileList;
        DirectoryInfo df = new DirectoryInfo(Path.GetTempPath());
        fileList = df.GetFiles("*.*",SearchOption.AllDirectories).Select<FileInfo, string>((f) => f.FullName).ToArray();
    
        // Parse the file list into a TreeNode collection
        TreeNode node = GetNodes(new TreeNode(), fileList);
    
        // Copy the new nodes to an array
        int nodeCount = node.Nodes.Count;
        TreeNode[] nodes = new TreeNode[nodeCount];
        node.Nodes.CopyTo(nodes, 0);
    
        // Invoke the treeview to add the nodes
        treeView1.Invoke((Action)delegate ()
        {
            treeView1.BeginUpdate(); // No visual updates until we say 
            treeView1.Nodes.Clear(); // Remove existing nodes
            treeView1.Nodes.AddRange(nodes); // Add the new nodes
            treeView1.EndUpdate(); // Allow the treeview to update visually
        });
    }
