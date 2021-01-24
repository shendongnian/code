        protected void Page_Load(object sender, EventArgs e)
        {
            TreeProvider cmsTree = new TreeProvider(MembershipContext.AuthenticatedUser);
            var node = cmsTree.SelectSingleNode(SiteContext.CurrentSiteName, "/", "en-US");
           
                TreeNodeCollection myChildren = node.AllChildren;
                IEnumerable<TreeNode> treeNodes = myChildren.AsEnumerable<TreeNode>();
                foreach (var tree in treeNodes.Where(x => x.NodeLevel ==0))
                {
                    System.Web.UI.WebControls.TreeNode ParentNode = new System.Web.UI.WebControls.TreeNode();
                    ParentNode.Text = "Root";
                    ParentNode.Value = tree.NodeID.ToString();
                    AddNodes(ParentNode);
                    tvContentTree.Nodes.Add(ParentNode);
                }           
        }
        /// <summary>
        /// Adding child for the parent 
        /// </summary>
        /// <param name="tNode"></param>
        private void AddNodes(System.Web.UI.WebControls.TreeNode tNode)
        {
            TreeProvider cmsTree = new TreeProvider(MembershipContext.AuthenticatedUser);
            var node = cmsTree.SelectSingleNode(SiteContext.CurrentSiteName, "/", "en-US");
            TreeNodeCollection myChildren = node.AllChildren;
            IEnumerable<TreeNode> childTreeNodes = myChildren.AsEnumerable<TreeNode>();
            foreach (var childTree in childTreeNodes.Where(x => x.NodeParentID == Convert.ToInt32(tNode.Value)))
            {
                System.Web.UI.WebControls.TreeNode ChildNode = new System.Web.UI.WebControls.TreeNode();
                ChildNode.Text = childTree.DocumentName.ToString();
                ChildNode.Value = childTree.NodeID.ToString();
                tNode.ChildNodes.Add(ChildNode);                
                AddNodes(ChildNode);
            }
        }
    
