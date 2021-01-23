    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        var node = e.Node as AliasesNode;
        if (node != null)
        {
            node.Click();
        }
    }
