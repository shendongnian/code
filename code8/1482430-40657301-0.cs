    public YourForm()
    {
        InitializeComponent();
        treeView.AfterSelect += TreeViewAfterSelect;
    }
    private void TreeViewAfterSelect(object sender, TreeViewEventArgs e)
    {
        string nodeText = treeView.SelectedNode.Text;
        // Update the panel here accordingly
    }
