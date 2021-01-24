    protected void TraverseNodes(TreeNodeCollection nodes, string action, int maxDepth = 2) 
        {
            foreach (TreeNode node in nodes)
            {
                if (node.ChildNodes.Count > 0 && node.Depth < maxDepth)
                    TraverseNodes(node.ChildNodes, action, maxDepth);
                //do something!!!
                var x = node.Text;
                node.Checked = !node.Checked;
            }
        }
