    private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
    {
        ToolTip tip = new ToolTip();
        tip.ToolTipTitle = e.Node.Name;
        while (e.Node == treeView.GetNodeAt(treeView.PointToClient(MousePosition)))
        {
            tip.Show(e.Node.Nodes.Count.ToString(), this, PointToClient(MousePosition));
        }
        tip.Dispose();
    }
