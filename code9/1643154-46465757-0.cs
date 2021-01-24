    public Form1()
    {
    	InitializeComponent();
    
    	treeView1.Nodes.Add("a");
    	treeView1.Nodes.Add("b");
    	treeView1.Nodes.Add("c");
    
    	treeView1.LostFocus += (s, e) => ((TreeView)s).SelectedNode = null;
    }
