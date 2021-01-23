    private TreeNode GetNodes(TreeNode parent, string[] fileList)
    {
        // build a TreeNode collection from the file list
        foreach (string strPath in fileList)
        {
            // Every time we parse a new file path, we start at the top level again
            TreeNode thisParent = parent;
    
            // split the file path into pieces at every backslash
            foreach (string pathPart in strPath.Split('\\'))
            {
                // check if we already have a node for this
                TreeNode[] tn = thisParent.Nodes.Find(pathPart, false);
    
                if (tn.Length == 0)
                {
                    // no node found, so add one
                    thisParent = thisParent.Nodes.Add(pathPart,pathPart);
                }
                else
                {
                    // we already have this node, so use it as the parent of the next part of the path
                    thisParent = tn[0];
                }
            }
    
        }
        return parent;
    }
