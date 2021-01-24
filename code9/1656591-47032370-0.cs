    class MyTreeView : System.Windows.Forms.TreeView
    {
        public TreeNode SelectedNode {get; set;}
        protected virtual void OnAfterSelect(TreeViewEventArgs e)
        {
             // raise event that previous node is DeSelected
             if (this.SelectedNode != null)
             {
                 this.OnNodeDeselected(e.Action);
             }
             if (e.Node != null && e.Node.IsSelected)
             {
                 this.OnNodeSelected(e);
             }
        }
        protected virtual void OnDeselectedNode(TreeViewAction action)
        {
             TreeViewEventArgs eventArgs = new TreeViewEventArgs(this.SelectedNode, action);
             // TODO: raise deselect event
             this.SelectedNode == null; // nothing selected anymore
        }
        protected virtual void OnSelectedNode(TreeViewEventArgs e)
        {
            // TODO: raise event to indicate a node has been selected
            this.SelectedNode = e.Node
        }
    }
