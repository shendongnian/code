    private void treeView1_MouseUp(object sender, MouseEventArgs e)
    {
    	var clickedNode = treeView1.GetNodeAt(e.X, e.Y);
    	if (clickedNode == null)
    	{
    		//clicked on background
            addChild(null);
    	}
    	else
    	{
    		//clicked on node
            addChild(clickedNode);
    	}
    }
