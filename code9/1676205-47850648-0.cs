    private void button1_Click(object sender, EventArgs e)
    {
        var visibleNodes = GetVisibleNodes(treeView1).ToList();
    }
    public IEnumerable<TreeNode> GetVisibleNodes(TreeView t)
    {
        var node = t.Nodes.Cast<TreeNode>().Where(x => x.IsVisible).FirstOrDefault();
        while (node != null)
        {
            var temp = node;
            node = node.NextVisibleNode;
            yield return temp;
        }
    }
