    private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
    {    
        //original code...
        // Note: When creating tree node for displaying file,
        // assign FileInfo to fileNode.Tag
        foreach (var file in directoryInfo.GetFiles()) {
            var fileNode = new TreeNode(file.Name + " (" + file.Length + " bytes)"+ file.CreationTime);
            fileNode.Tag = file;
            directoryNode.Nodes.Add(fileNode);
        }
        //original code...
    }
    
    
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        // Note: Both DirectoryInfo and FileInfo, inherrits FileSystemInfo
        // thus you can cast both to FileSystemInfo.
        var fsInfo = treeView1.SelectedNode.Tag as FileSystemInfo;
        if (fsInfo != null)
        {             
            var creationTime = fsInfo.CreationTime.ToString();
                label1.Text = creationTime;
            var lastAccessTime = fsInfo.LastAccessTime;
                label2.Text = lastAccessTime.ToString();
            var lastWriteTime = fsInfo.LastWriteTime;
                label3.Text = lastWriteTime.ToString();
        }
        else
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }
    }
