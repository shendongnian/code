    public class TreeNode<T>
    {
        #region Properties
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public ICollection<TreeNode<T>> Children { get; set; }
        public Boolean IsRoot
        {
            get { return Parent == null; }
        }
        public Boolean IsLeaf
        {
            get { return Children.Count == 0; }
        }
        public int Level
        {
            get
            {
                if (this.IsRoot)
                {
                    return 0;
                }
                return Parent.Level + 1;
            }
        }
        #endregion
    
        public TreeNode(T data)
        {
            this.Data = data;
            this.Children = new LinkedList<TreeNode<T>>();
            this.ElementsIndex = new LinkedList<TreeNode<T>>();
            this.ElementsIndex.Add(this);
        }
        public TreeNode<T> AddChild(T child)
        {
            TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
            this.Children.Add(childNode);
            this.RegisterChildForSearch(childNode);
            return childNode;
        }
        public override string ToString()
        {
            return Data != null ? Data.ToString() : "[data null]";
        }
        
        private ICollection<TreeNode<T>> ElementsIndex { get; set; }
        private void RegisterChildForSearch(TreeNode<T> node)
        {
            ElementsIndex.Add(node);
            if (Parent != null)
            {
                Parent.RegisterChildForSearch(node);
            } 
        }
        public TreeNode<T> FindTreeNode(Func<TreeNode<T>, bool> predicate)
        {
            return this.ElementsIndex.FirstOrDefault(predicate);
        }
    }
