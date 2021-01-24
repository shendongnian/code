    private void tvResources_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        CalculateAB( e.Node );
    }
    private void CalculateAB( TreeNode node )
    {
        int a = 0;
        int b = 0;
        foreach ( TreeNode child in node.Nodes )
        {
            if ( child.Nodes.Count() > 0 )
            {
                a++;
            } 
            else
            {
                b++;
            }
        }
        node.Text += @" - " + a + "/" + b;
    }
