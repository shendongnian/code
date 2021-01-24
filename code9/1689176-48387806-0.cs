    private void myTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs eventArgs)
    {
        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
        string node = "\tNode: " + eventArgs.Node; // This is the new node
        string action = "\tAction: " + eventArgs.Action; // ByMouse
        string cancel = "\tCancel: " + eventArgs.Cancel; // False
        //Get the current selected node/old node after the select processed
        var oldNode = ((TreeView) sender).SelectedNode;
    }
