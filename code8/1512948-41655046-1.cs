    private string TreeViewToString(TreeView tv, string delimiter) {
        var result = new StringBuilder();
        
        foreach (TreeNode node in tv.Nodes) {
            TraverseNodes(node, delimited, result);
        }
        if (result.Length < delimiter.Length) {
            return result.ToString();
        } else {
            return result.ToString(0, result.Length - delimiter.Length); 
        }             
    }
    // recursive part
    private void TraverseNodes(TreeNode node, string delimiter, StringBuilder result) {
        result.AppendFormat("{0}{1}", node.Text, delimiter);      // add node to string
        foreach (TreeNode subNode in node.Nodes) {
            TravserseNodes(subNode, delimiter, result);           // recurse into nodes children
        }
    }
