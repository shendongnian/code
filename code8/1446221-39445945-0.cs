    protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("~/MyFolder/"));
                    this.PopulateTreeView(rootInfo, null);
                }
            }
             
            private void PopulateTreeView(DirectoryInfo dirInfo, TreeNode treeNode)
            {
                foreach (DirectoryInfo directory in dirInfo.GetDirectories())
                {
                    TreeNode directoryNode = new TreeNode
                    {
                        Text = directory.Name,
                        Value = directory.FullName
                    };
             
                    if (treeNode == null)
                    {
                        //If Root Node, add to TreeView.
                        TreeView1.Nodes.Add(directoryNode);
                    }
                    else
                    {
                        //If Child Node, add to Parent Node.
                        treeNode.ChildNodes.Add(directoryNode);
                    }
             
                    //Get all files in the Directory.
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        //Add each file as Child Node.
                        TreeNode fileNode = new TreeNode
                        {
                            Text = file.Name,
                            Value = file.FullName,
                            Target = "_blank",
                            NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                        };
                        directoryNode.ChildNodes.Add(fileNode);
                    }
             
                    PopulateTreeView(directory, directoryNode);
                }
            }
