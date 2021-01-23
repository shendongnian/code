    ToolTip tip = new ToolTip();
    
    private void treeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
    {
                
        tip.ToolTipTitle = e.Node.Name;
        tip.Show(e.Node.Nodes.Count.ToString(), this, PointToClient(MousePosition));
                
    }
    
    private void treeView_MouseMove(object sender, MouseEventArgs e)
    {
        if (treeView.GetNodeAt(treeView.PointToClient(MousePosition)) == null)
            tip.Hide(this);
    }
