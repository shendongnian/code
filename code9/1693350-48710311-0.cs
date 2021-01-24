           public Form1()
            {
                InitializeComponent();
                TreeNode newNode1 = new TreeNode("Node 1");
                treeView1.Nodes.Add(newNode1);
                TreeNode newNode1a = new TreeNode("Node 1a");
                newNode1.Nodes.Add(newNode1a);
                treeView1.Click += new EventHandler(treeView1_Click);
                TreeNode newNode2 = new TreeNode("Node 2");
                treeView1.Nodes.Add(newNode2);
                TreeNode newNode3 = new TreeNode("Node 3");
                treeView1.Nodes.Add(newNode3);
            }
            void treeView1_Click(object sender, EventArgs e)
            {
                TreeView  node = sender as TreeView;
                if (node != null)
                {
                    TreeNode selectedNode = node.SelectedNode;
                    string nodeName = selectedNode.Name;
                    Boolean expanded = selectedNode.IsExpanded;
                }
            }
