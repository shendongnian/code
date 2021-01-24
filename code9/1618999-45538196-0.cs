    private void CloseConnection_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var currentNode = menuItem.Tag as TreeNode;
            currentNode.Collapse(); // Here will verify whether the current node has child nodes.
            currentNode.Nodes.Clear();
        }
