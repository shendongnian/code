    var nodes = new Stack<TreeNode>(treeViewFilter.Nodes.Cast<TreeNode>());
    while (nodes.Count > 0) {
      var n = nodes.Pop();
      if (!n.Checked) {
        if (n.Parent != null) {
          n.Parent.Nodes.Remove(n);
        } else {
          treeViewFilter.Nodes.Remove(n);
        }
      } else {
        foreach (TreeNode tn in n.Nodes) {
          nodes.Push(tn);
        }
      }
    }
