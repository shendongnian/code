    viewer.Click += GraphNode_Click;
    ...
    private void GraphNode_Click(object sender, EventArgs e)
    {
        GViewer viewer = sender as GViewer;
        if (viewer.SelectedObject is Node)
        {
            Node node=viewer.SelectedObject as Node;
            //...do works here
        }
    }
